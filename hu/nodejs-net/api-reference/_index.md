---
title: API Referencia
type: docs
weight: 50
url: /hu/nodejs-net/api-reference/
description: "Az Aspose.Slides for Node.js via .NET dokumentációja az Aspose.Slides for .NET API-referencián alapul. Tekintse meg, hogyan térnek le a .NET osztály- és tagnevek a JavaScript-re."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via .NET saját API-referenciával nem rendelkezik. A csomag az Aspose.Slides for .NET osztályait ugyanazokkal a nevekkel, camelCase tagnevekkel teszi elérhetővé a JavaScript számára, így a [Aspose.Slides for .NET API-referencia](https://reference.aspose.com/slides/net/) dokumentálja az osztályait, tagjait és felsorolásait.

## **.NET nevek leképezése JavaScript-re**

A .NET API-referenciában megtalált tag használatához alkalmazza a következő szabályokat:

- **Az osztályok és felsorolások megtartják .NET nevüket**, és így a felsorolásértékek is: `Presentation`, `ShapeType.Rectangle`, `SaveFormat.Pdf`. Importálja őket a csomagból: `const { Presentation, SaveFormat } = require("aspose.slides.via.net");`.
- **A tulajdonságok és metódusok kisbetűvel kezdődnek.** `Presentation.Slides` `presentation.slides`-ra alakul, és a `ShapeCollection.AddAutoShape` `shapes.addAutoShape` lesz. A tulajdonságok maradnak tulajdonságok: olvasásuk és értékadásuk zárójelek nélkül történik.
- **A gyűjtemény elemei `get(index)` segítségével olvashatók**, az elemek száma pedig `count`-tel: `presentation.slides.get(0)` a `presentation.Slides[0]` helyett.
- **Néhány túlterhelés külön nevet kap.** Például a `Slide.GetImage(Size)` túlterhelés `slide.getImageWithImageSize({ width, height })`. Mások egy metódust osztanak meg opcionális záró argumentumokkal: `presentation.save(path, format, options, slides)` lefedi a több `Presentation.Save` túlterhelést, és a `new Presentation(null, buffer)` egy prezentációt nyit meg egy `Buffer`-ből. Minden osztály egy fájl a csomag `lib` mappájában (például `node_modules/aspose.slides.via.net/lib/Slide.js`), ahol megtekintheti a pontos neveket.
- **Az előadásokat `dispose`-el szabadítsa fel** amikor befejezte őket; a JavaScriptben nincs `using` utasítás.

A csomag nem csomagolja be minden .NET tagot. Ha egy .NET API-referenciában szereplő tag hiányzik az osztályfájlból, akkor nem áll rendelkezésre JavaScriptben.

## **Példa**

Az alábbi szkript a fenti szabályokat használja. Minden megjegyzés mutatja azt a .NET hívást, amelynek a következő sor felel meg. Egy téglalapot szöveggel ad hozzá az első diára, a diát 960 × 540 képpontos PNG képként rendereli, és a prezentációt PDF‑ként menti. Futtassa egy olyan projekt mappából, ahol a csomag telepítve van a [Telepítés](/slides/hu/nodejs-net/installation/) leírásának megfelelően.

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

A szkript a `slide.png` és `slide.pdf` fájlokat írja az aktuális mappába. Mindkettő a szöveges téglalapot jeleníti meg. Licenc nélkül egy értékelési vízjelet is tartalmaznak; lásd a [Licenc](/slides/hu/nodejs-net/licensing/) részt.

A felhasznált tagok részleteiért lásd a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), [ShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addautoshape/), [TextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/textframe/text/) és a [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) hivatkozást az Aspose.Slides for .NET API-referenciában.