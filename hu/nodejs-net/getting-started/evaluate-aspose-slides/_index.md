---
title: Az Aspose.Slides értékelése
type: docs
weight: 120
url: /hu/nodejs-net/evaluate-aspose-slides/
keywords:
- Aspose.Slides értékelése
- értékelő verzió
- értékelő vízjel
- próba korlátozások
- ideiglenes licenc
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js via .NET értékelő verziója milyen korlátozásokkal jár, egy szkripttel, amely bemutatja mindkét korlátozást és hogyan lehet őket licenccel eltávolítani."
---
## **Áttekintés**

Az Aspose.Slides for Node.js via .NET értékelő verziója ugyanaz az npm csomag, mint a licencelt változat. Licenc nélkül értékelő módban fut: minden funkció működik, de a mentett prezentációk és a legtöbb export vízjelet tartalmaz, és a kódod által visszaolvasott szöveg csonkolva van. Ez a cikk leírja mindkét korlátozást, és megmutatja, hogyan lehet őket eltávolítani.

## **Értékelő korlátozások**

**Értékelő vízjel minden dián.** Ha licenc nélkül mented a prezentációt, az Aspose.Slides egy szövegdobozt ad a mentett fájl minden diájának közepéhez. A szövegdoboz zárolt, és a szövege: "Evaluation only." után egy terméksor és egy szerzői jogi sor következik. A vízjel a mentett fájlba kerül, nem a memóriában lévő prezentációba, és a prezentáció megnyitása nem ad hozzá újat. Azonban egy olyan fájl, amelyet már értékelő módban mentettek, már tartalmazza a szövegdobozt, így a megnyitás és újra mentés során egy második vízjel kerül minden diára.

Ugyanez a vízjel jelenik meg a kimeneten, amikor PDF-re, XPS-re vagy HTML-re exportálsz, illetve diákat képként renderelsz. Ha egy már értékelő módban mentett prezentációt renderelsz, a kép mind a mentett, mind a renderelt vízjelet mutatja.

**Csonkolt szöveg, amikor a kódod olvassa.** A kódod által a szövegkeret, bekezdés vagy rész `text` tulajdonságán keresztül olvasott szöveg az első öt karakterre van vágva, ezt követi a figyelmeztetés "... text has been truncated due to evaluation version limitation." Öt vagy kevesebb karakteres szöveg teljes egészében visszaadódik. Ez minden diára vonatkozik, és még a kód által mostanában hozzárendelt szövegre is. A Markdown és HTML5 exportok is ugyanígy csonkolódnak.

A kódod által írt szöveg teljes egészében mentésre kerül: a PPTX fájlok, PDF oldalak és diaképek a teljes szöveget tartalmazzák.

## **A korlátozások megtekintése egy szkriptben**

A következő szkript mindkét korlátozást mutatja be. Feltételezi, hogy a csomagot az [Installation](/slides/hu/nodejs-net/installation/) útmutató szerint telepítetted, és a projekt mappájából futtatod. Egy téglalapot egy mondattal ad az első diához, visszaolvassa a mondatot, menti a prezentációt `evaluation.pptx` néven, majd újra megnyitja a fájlt a dián lévő alakzatok számolásához.

```javascript
const asposeSlides = require("aspose.slides.via.net");
const { Presentation, ShapeType, SaveFormat } = asposeSlides;

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);
    const rectangle = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 500, 100);
    rectangle.textFrame.text = "Quarterly results are ready for review.";

    // Licenc nélkül csak az első öt karakter kerül visszaadásra.
    console.log("Text read back:", rectangle.textFrame.text);

    // A mentés minden diára hozzáadja az értékelő vízjelet a fájlban.
    presentation.save("evaluation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const savedPresentation = new Presentation("evaluation.pptx");
try {
    // A dia most tartalmazza a téglalapot és a vízjel szövegdobozát.
    console.log("Shapes on the saved slide:", savedPresentation.slides.get(0).shapes.count);
} finally {
    savedPresentation.dispose();
}
```

Licenc nélkül a szkript a következőt írja ki:

```text
Text read back: Quart... text has been truncated due to evaluation version limitation.
Shapes on the saved slide: 2
```

A második alakzat a vízjel szövegdoboz. Nyisd meg az `evaluation.pptx` fájlt, hogy lásd a teljes mondatot a téglalapon és a vízjelet a dia közepén.

## **A korlátozások eltávolítása**

A két korlátozás eltávolításához alkalmazz licencet, mielőtt bármilyen `Presentation` objektumot létrehoznál. A [Licensing](/slides/hu/nodejs-net/licensing/) bemutatja, hogyan kell licencfájlt alkalmazni.

{{% alert color="success" title="Tip" %}}
Az Aspose.Slides értékelő korlátozások nélküli teszteléséhez, mielőtt megvásárolnád, kérj ingyenes **30 napos ideiglenes licencet**. A részletekért lásd a [Hogyan lehet ideiglenes licencet szerezni?](https://purchase.aspose.com/temporary-license) oldalt.
{{% /alert %}}

## **GYIK**

**Az értékelő mód korlátozza a diák számát?**

Nem. A prezentációk minden diájukat magukkal hozva, megnyitva és mentve maradnak. A vízjel és a szövegcsonkolás minden diára egyformán vonatkozik.

**Miért jelenik meg a vízjel kétszer az exportált diaképeken?**

A prezentációt már értékelő módban mentették, mielőtt renderelted volna, ezért már tartalmaz egy vízjel szövegdobozt, és licenc nélkül a renderelés egy újat rajzol rá.

**Ellenőrizhetem, hogy a kódom helyes szöveget állít elő értékelő módban?**

Igen. Nyisd meg a mentett fájlt vagy az exportált PDF-et: azok a teljes szöveget tartalmazzák. Csak a kódod által visszaolvasott szöveg, valamint a Markdown vagy HTML5 kimenet van csonkolva.