---
title: Référence API
type: docs
weight: 50
url: /fr/nodejs-net/api-reference/
description: "Aspose.Slides for Node.js via .NET est documenté par la référence API Aspose.Slides for .NET. Voir comment les noms de classes et de membres .NET sont mappés vers JavaScript."
---
## **Vue d'ensemble**

Aspose.Slides for Node.js via .NET n'a pas de référence API propre. Le package expose les classes d'Aspose.Slides for .NET à JavaScript sous les mêmes noms, avec des noms de membres en camelCase, de sorte que la [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/fr/net/) documente ses classes, membres et énumérations.

## **Mapper les noms .NET en JavaScript**

Pour utiliser un membre que vous trouvez dans la référence API .NET, appliquez ces règles :

- **Les classes et les énumérations conservent leurs noms .NET**, tout comme les valeurs d'énumération : `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importez‑les depuis le package : `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **Les propriétés et les méthodes commencent par une lettre minuscule.** `Presentation.Slides` devient `presentation.slides`, et `ShapeCollection.AddAutoShape` devient `shapes.addAutoShape`. Les propriétés restent des propriétés : vous les lisez et les affectez sans parenthèses.
- **Les éléments de collection sont lus avec `get(index)`**, et le nombre d'éléments avec `count` : `presentation.slides.get(0)` au lieu de `presentation.Slides[0]`.
- **Certaines surcharges obtiennent des noms distincts.** Par exemple, la surcharge `Slide.GetImage(Size)` devient `slide.getImageWithImageSize({ width, height })`. D'autres partagent une même méthode avec des arguments optionnels en fin : `presentation.save(path, format, options, slides)` couvre plusieurs surcharges `Presentation.Save`, et `new Presentation(null, buffer)` ouvre une présentation depuis un `Buffer`. Chaque classe est un fichier dans le dossier `lib` du package (par exemple, `node_modules/aspose.slides.via.net/lib/Slide.js`), où vous pouvez consulter les noms exacts.
- **Libérez les présentations avec `dispose`** lorsque vous avez fini de les utiliser ; JavaScript n'a pas d'instruction `using`.

Le package n'encapsule pas chaque membre .NET. Si un membre de la référence API .NET est absent du fichier de classe, il n'est pas disponible en JavaScript.

## **Exemple**

Le script suivant utilise les règles ci‑dessus. Chaque commentaire montre l’appel .NET auquel correspond la ligne suivante. Il ajoute un rectangle avec texte à la première diapositive, rend la diapositive en image PNG de 960 × 540 pixels, et enregistre la présentation au format PDF. Exécutez‑le depuis un dossier de projet où le package est installé comme décrit dans la [Installation](/slides/fr/nodejs-net/installation/).

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat, ImageFormat } = asposeSlides;

const presentation = new Presentation();
try {
    // .NET: presentation.Slides[0]
    const slide = presentation.slides.get(0);

    // .NET: slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100)
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

    // .NET: rectangle.TextFrame.Text = "..."
    rectangle.textFrame.text = "Names follow the .NET API in camelCase.";

    // .NET: slide.GetImage(new Size(960, 540))
    const slideImage = slide.getImageWithImageSize({ width: 960, height: 540 });
    slideImage.save("slide.png", ImageFormat.Png);
    slideImage.dispose();

    // .NET: presentation.Save("slide.pdf", SaveFormat.Pdf)
    presentation.save("slide.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

Le script écrit `slide.png` et `slide.pdf` dans le dossier actuel. Les deux affichent le rectangle avec son texte. Sans licence, ils affichent également un filigrane d'évaluation ; voir la [Licence](/slides/fr/nodejs-net/licensing/).

Pour plus de détails sur les membres utilisés ici, voir [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/fr/net/aspose.slides/textframe/text/) et [Slide.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/slide/getimage/) dans la référence API Aspose.Slides for .NET.