---
title: PowerPoint konvertálása PDF-be Node.js-en keresztül .NET
linktitle: PowerPoint PDF-be
type: docs
weight: 30
url: /hu/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint PDF-be
- PowerPoint konvertálása PDF-be
- PPTX PDF-be
- PPT PDF-be
- ODP PDF-be
- bemutató mentése PDF-ként
- PDF/A
- PdfOptions
- PowerPoint
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Konvertálja a PPTX, PPT és ODP bemutatókat PDF-be JavaScript használatával az Aspose.Slides for Node.js via .NET segítségével, és hozza létre archiválási célú PDF/A fájlokat a PdfOptions segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via .NET a PowerPoint és OpenDocument bemutatókat PDF formátumba konvertál a Microsoft PowerPoint nélkül. Minden látható dia egy PDF-oldallá válik, amely mérete megegyezik a diáéval, és a szöveg kijelölhető és kereshető marad. Ez a cikk bemutatja az alapértelmezett konverziót, valamint egy PDF/A konverziót a [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) segítségével.

A példák egy `sample.pptx` nevű bemutatót várnak a projekt mappájában, amelyet a [Installation](/slides/hu/nodejs-net/installation/) részben állít be. Bármilyen PowerPoint bemutató megfelelő. Mentse el minden példát `.js` fájlként a projekt mappájába, és futtassa azt a mappából a `node` paranccsal.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Node.js via .NET saját API-referenciával nem rendelkezik. A Aspose.Slides for .NET API-t tükrözi camelCase nevekkel, így ebben a cikkben szereplő API hivatkozások a megfelelő osztályokra és tagokra mutatnak a [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/) oldalán.
{{% /alert %}}

## **Bemutató konvertálása PDF-be**

A bemutató PDF-be konvertálásához kövesse az alábbi lépéseket:

1. Nyissa meg a bemutatót a fájl útvonalát a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) konstruktorának átadva. Ugyanez a kód működik PPTX, PPT és ODP fájlok esetén.
2. Hívja meg a [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) metódust a kimeneti útvonallal és a `SaveFormat.Pdf` értékkel.
3. Hívja meg a `dispose` metódust egy `finally` blokkban a bemutató hátterét képező .NET erőforrások felszabadításához.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

A szkript a `sample.pdf` fájlt a projekt mappájába írja. A konverzió az alapértelmezett beállításokat használja: minden nem rejtett dia egy oldallá válik, a diák sorrendjében. Licenc nélkül minden oldal egy értékelő vízjelet is mutat; lásd a [Licensing](/slides/hu/nodejs-net/licensing/) részt.

## **Bemutató konvertálása PDF/A-ba**

A kimenet szabályozásához adjon át egy [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) objektumot a `save` harmadik argumentumaként. A következő példa a [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) tulajdonságot `PdfCompliance.PdfA2b`-re állítja, amely PDF/A-2b fájlt eredményez. A PDF/A az ISO szabvány a hosszú távú archiváláshoz: többek között előírja, hogy a dokumentum által használt minden betűtípust be kell ágyazni a fájlba.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

A szkript a `sample-pdfa.pdf` fájlt ugyanazzal a lapok számával hozza létre, mint az alapértelmezett konverzió. Annak ellenőrzéséhez, hogy a fájl megfelel-e a szabványnak, ellenőrizze egy PDF/A validátorral, például a [veraPDF](https://verapdf.org/) segítségével. Más [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) értékek más szabványokat választanak, például `PdfA1b`, `PdfA2a`, vagy a hozzáférhetőséghez a `PdfUa`-t.

## **GYIK**

**Hogyan tudom a rejtett diákot is belefoglalni a PDF-be?**

A rejtett diák alapértelmezés szerint kihagyásra kerülnek. Állítsa a `PdfOptions` [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) tulajdonságát `true` értékre, és adja át az opciókat a `save` metódusnak.

**Lehet a PDF-et jelszóval védeni?**

Igen. A `save` meghívása előtt állítsa be a `PdfOptions` [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) tulajdonságát. A PDF-olvasók ekkor a fájl megnyitása előtt kérik a jelszót.

**Csak bizonyos diákot konvertálhatok?**

Igen. A `save` negyedik argumentumaként adjon át egy tömböt a diák pozícióival. A pozíciók 1‑től kezdődnek, és a harmadik argumentum lehet `null`, ha nincs szükség opciókra: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` egy PDF‑et hoz létre az első és a harmadik diákkal.

**Miért néz ki másképp a szöveg, amikor Linuxon konvertálok?**

Az Aspose.Slides csak azokon a gépeken telepített betűtípusokat tudja használni, ahol a konverzió fut. Ha egy bemutató olyan betűtípust használ, amely hiányzik, például a Calibri egy tipikus Linux szerveren, az Aspose.Slides egy telepített betűtípust helyettesít, ami megváltoztathatja a szöveg megjelenését és a sortöréseket. Telepítse a bemutatók által használt betűtípusokat, hogy ugyanazt az eredményt kapja, mint Windows alatt.

**Kérhetek PDF-et Bufferként a fájl helyett?**

Igen. A `presentation.saveToBuffer(SaveFormat.Pdf)` a PDF-et Node.js `Buffer`‑ként adja vissza, ami kényelmes, ha az eredményt HTTP‑válaszban küldi. Másodként a `PdfOptions` objektumot is elfogadja.