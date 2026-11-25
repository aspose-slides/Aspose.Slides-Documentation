---
title: Interrompre les opérations de présentation de longue durée dans Node.js
linktitle: Interrompre les opérations de présentation
type: docs
weight: 120
url: /fr/nodejs-java/support-for-interruptable-library/
keywords:
- opérations interrompables
- jeton d'interruption
- jeton d'annulation
- délai d'expiration de conversion
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Annuler les opérations de présentation de longue durée dans Aspose.Slides pour Node.js via Java, définir un délai d'expiration de conversion et suivre les diapositives exportées avant l'annulation."
---
## **Aperçu**

Aspose.Slides for Node.js via Java prend en charge l'annulation lors du chargement, de l'enregistrement ou du rendu d'une présentation. Vous pouvez également vérifier le même jeton dans votre propre boucle d'exportation pour vous arrêter avant la diapositive suivante et renvoyer les numéros des diapositives déjà enregistrées.

## **Interrompre une opération de présentation**

Créez un [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), obtenez son jeton avec [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken), et passez‑le à [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Utilisez ces options lors de la construction du [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Appeler [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) sur la source demande l'annulation de l'opération en cours. Aspose.Slides s'arrête lors de la prochaine vérification du jeton.

### **Définir un délai d'expiration de conversion**

L'exemple suivant autorise 20 secondes pour ouvrir `sample.pptx` et l'enregistrer sous `sample.pdf`. Le constructeur et la sauvegarde s'exécutent tous deux de manière asynchrone via le pont Java afin que le minuteur Node.js puisse se déclencher pendant l'une ou l'autre opération. L'exemple vérifie le jeton après le chargement et de nouveau après l'enregistrement, car un appel de bibliothèque peut retourner après une demande d'annulation. Il libère la présentation lorsque l'opération se stabilise et efface le minuteur si la conversion se termine tôt. Si une annulation se produit pendant l'enregistrement, le fichier de sortie peut déjà exister et être incomplet.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Pour convertir au format PowerPoint plus ancien avec une limite de 10 secondes, transmettez `"sample.ppt"`, `slides.SaveFormat.Ppt` et `10000` comme les trois derniers arguments.

## **Arrêter avant de traiter la diapositive suivante**

Utilisez [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) avant chaque export lorsque l'appelant peut utiliser un résultat partiel. La surcharge de [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) pour les diapositives sélectionnées accepte un `int[]` Java contenant les numéros de diapositives à partir de 1. Enregistrez chaque numéro uniquement après que son PDF a été enregistré avec succès.

Exécutez l'exemple avec une présentation nommée `sample.pptx` contenant au moins deux diapositives. Pour démontrer l'annulation entre les exportations, l'exemple la demande immédiatement après l'enregistrement de la première diapositive.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

L'exemple écrit `slide-1.pdf` et affiche `Starting slide 1` suivi de `Completed: [1]`. La boucle observe l'annulation avant de démarrer la diapositive 2. Si un enregistrement est lui‑même interrompu, la liste retournée ne contient que les exportations réussies précédemment.

Pour permettre à l'appelant de gérer l'annulation comme une erreur, remplacez la vérification et son `break` en haut de la boucle par [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), appelé sous la forme `token.throwIfInterruptionRequested()`. Utilisez la même vérification d'exception après l'enregistrement et supprimez le `try`/`catch` qui l'entoure. Avec la même entrée, le premier PDF est toujours écrit, et la deuxième itération génère une exception avant que la fonction ne puisse renvoyer une liste.

## **FAQ**

**Quand devrais-je demander l'annulation ?**  
Demandez l'annulation lorsqu'une échéance expire ou que l'application n'a plus besoin du résultat. Le chargement, l'enregistrement et le rendu peuvent tous utiliser le jeton passé à la présentation lors de sa construction.

**En quoi la source et le jeton diffèrent‑ils ?**  
La source permet à l'application de demander l'annulation. Le jeton permet à Aspose.Slides et à votre propre code de vérifier cette demande.

**Un minuteur Node.js peut‑il interrompre une sauvegarde synchrone ?**  
Une sauvegarde synchrone bloque JavaScript sur le thread appelant. Utilisez les appels du pont Java asynchrone présentés dans l'exemple de délai afin que le minuteur puisse demander l'annulation pendant que la sauvegarde s'exécute.

**L'annulation prend‑elle effet immédiatement ?**  
L'annulation est coopérative. Une opération en cours s'arrête lorsqu'elle détecte la demande. Une opération déjà terminée conserve son résultat.

**Plusieurs opérations peuvent‑elles partager une même source ?**  
Oui. Appeler `interrupt()` demande l'annulation pour chaque opération utilisant un jeton provenant de cette source. Utilisez une source distincte pour chaque opération que vous souhaitez annuler indépendamment.