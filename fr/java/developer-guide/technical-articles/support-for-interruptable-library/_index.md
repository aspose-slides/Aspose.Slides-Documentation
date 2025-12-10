---
title: Support de la bibliothèque Interruptable
type: docs
weight: 120
url: /fr/java/support-for-interruptable-library/
keywords:
- bibliothèque interruptable
- jeton d'interruption
- jeton d'annulation
- tâche de longue durée
- interruption de tâche
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Rendez les tâches de longue durée annulables avec Aspose.Slides for Java. Interrompez en toute sécurité le rendu et les conversions pour PowerPoint et OpenDocument, avec des exemples."
---

## **Bibliothèque Interruptable**

Dans [Aspose.Slides 18.4](https://releases.aspose.com/slides/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), nous avons introduit les classes [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/). Elles permettent d’interrompre des tâches longues telles que la désérialisation, la sérialisation et le rendu.

- [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) est la source du ou des jetons transmis à [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Lorsque [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) est défini et que l’instance [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) est passée au constructeur [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/), appeler [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) interrompt toute tâche longue associée à cette [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).

Le fragment de code suivant montre comment interrompre une tâche en cours :
```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // exécuter l'action dans un thread séparé
Thread.sleep(10000);     // délai d'attente
tokenSource.interrupt(); // arrêter la conversion
```


## **FAQ**

**Quel est le but de la bibliothèque d’interruption Aspose.Slides ?**

Elle fournit un mécanisme pour interrompre les opérations longues—telles que le chargement, l’enregistrement ou le rendu de présentations—avant qu’elles ne se terminent. Cela est utile lorsque le temps de traitement doit être limité ou que la tâche n’est plus nécessaire.

**Quelle est la différence entre [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) et [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

- `InterruptionToken` est transmis à l’API Aspose.Slides et vérifié pendant les opérations longues.
- `InterruptionTokenSource` est utilisé dans votre code pour créer des jetons et déclencher des interruptions en appelant `Interrupt()`.

**Quelles tâches peuvent être interrompues ?**

Toute tâche Aspose.Slides qui accepte un [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/)—comme le chargement d’une présentation avec `Presentation(path, loadOptions)` ou l’enregistrement avec `Presentation.save(...)`—peut être interrompue.

**L’interruption se produit‑elle immédiatement ?**

Non. L’interruption est coopérative : l’opération vérifie périodiquement le jeton et s’arrête dès qu’elle détecte que [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) a été appelé.

**Que se passe‑t‑il si j’appelle [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) après qu’une tâche soit déjà terminée ?**

Rien—l’appel n’a aucun effet si la tâche correspondante est déjà terminée.

**Puis‑je réutiliser le même [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/) pour plusieurs tâches ?**

Oui—mais après avoir appelé [Interrupt()](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) sur cette source, toutes les tâches utilisant ses jetons seront interrompues. Utilisez des sources de jetons distinctes pour gérer les tâches de façon indépendante.