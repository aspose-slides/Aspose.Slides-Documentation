---
title: ActiveX vezérlők kezelése prezentációkban JavaScript használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Node.js a Java-n keresztül az ActiveX-et a PowerPoint prezentációk automatizálására és fejlesztésére, lehetővé téve a fejlesztők számára a diák erőteljes irányítását."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for Node.js a Java-n keresztül lehetővé teszi az ActiveX vezérlők hozzáadását és kezelését, de ezek kezelése egy kicsit bonyolultabb a szokásos prezentációs alakzatokhoz képest. Implementáltuk a Media Player Active vezérlő hozzáadásának támogatását az Aspose.Slides-ben. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [ShapeCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shapecollection/). Ők a különálló [ControlCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/controlcollection/) részei. Ebben a témában megmutatjuk, hogyan dolgozzunk velük.

## **Media Player ActiveX vezérlő hozzáadása a diára**
Az ActiveX Media Player vezérlő hozzáadásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból, és generáljon egy üres prezentációt.
1. Hozzáférés a cél diához a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályban.
1. Adja hozzá a Media Player ActiveX vezérlőt a [ControlCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/controlcollection/) által biztosított [addControl](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) metódussal.
1. Hozzáférés a Media Player ActiveX vezérlőhöz, és a tulajdonságai segítségével állítsa be a video útvonalát.
1. Mentse a prezentációt PPTX fájlként.

Ez a minta kód, a fenti lépések alapján, bemutatja, hogyan adjon Media Player ActiveX vezérlőt egy diára:

```javascript
// Üres prezentációpéldány létrehozása
var pres = new aspose.slides.Presentation();
try {
    // Media Player ActiveX vezérlő hozzáadása
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Media Player ActiveX vezérlő elérése és a videó útvonal beállítása
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Prezentáció mentése
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **ActiveX vezérlő módosítása**

Egy egyszerű ActiveX vezérlő, például egy szövegdoboz vagy egy egyszerű parancsgomb kezelése egy dián, a következőképpen:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból, és töltse be a prezentációt, amelyben ActiveX vezérlők szerepelnek.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Hozzáférés a dia ActiveX vezérlőihez a [ControlCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/controlcollection/) elérésével.
1. A TextBox1 ActiveX vezérlőhöz való hozzáférés a [Control](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/control/) objektummal.
1. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, mint a szöveg, betűtípus, betűmagasság és a keret pozíciója.
1. Hozzáférés a második vezérlőhöz, amely CommandButton1 néven szerepel.
1. Módosítsa a gomb feliratát, betűtípusát és pozícióját.
1. Módosítsa az ActiveX vezérlők kereteinek pozícióját.
1. Írja a módosított prezentációt PPTX fájlba.

Ez a minta kód, a fenti lépések alapján, bemutatja, hogyan kezeljen egy egyszerű ActiveX vezérlőt:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// A prezentáció elérése ActiveX vezérlőkkel
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Az első dia elérése a prezentációban
    var slide = pres.getSlides().get_Item(0);
    // A TextBox szövegének módosítása
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // A helyettesítő kép módosítása. A PowerPoint lecseréli ezt a képet az ActiveX aktiválása során,
        // ezért néha rendben van, ha a kép változatlan marad.
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "window"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // A gomb feliratának módosítása
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Changing substitute
        var image = java.newInstanceSync("java.awt.image.BufferedImage", control.getFrame().getWidth(), control.getFrame().getHeight(), java.getStaticFieldValue("java.awt.image.BufferedImage", "TYPE_INT_ARGB"));
        var graphics = image.getGraphics();
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "control"));
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());
        var font = java.newInstanceSync("java.awt.Font", control.getProperties().get_Item("FontName"), java.getStaticFieldValue("java.awt.Font", "PLAIN"), 16);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "windowText"));
        graphics.setFont(font);
        var metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, java.newFloat((image.getWidth() - metrics.stringWidth(newCaption)) / 2), 20);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlLtHighlight"));
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlHighlight"));
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlShadow"));
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);
        graphics.setColor(java.getStaticFieldValue("java.awt.SystemColor", "controlDkShadow"));
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);
        graphics.dispose();
        
        var baos = java.newInstanceSync("java.io.ByteArrayOutputStream");
        imageio.write(image, "PNG", baos);
        var byteStream = Readable.from([Buffer.from(baos.toByteArray())]);
        aspose.slides.readBytesFromStream(byteStream, (imgData) => {
            control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(imgData));
        });
    }
    // 100 ponttal lefelé mozgatás
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // vezérlők eltávolítása
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Az Aspose.Slides megőrzi az ActiveX vezérlőket olvasás és újbóli mentés során, ha a Python környezetben nem futtathatók?**

Igen. Az Aspose.Slides a prezentáció részének tekinti őket, és képes olvasni/módosítani a tulajdonságaikat és kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, kezelt elemek (gombok, szövegdobozok, médialejátszó), míg az [OLE](/slides/hu/nodejs-java/manage-ole/) beágyazott alkalmazásobjektusokra utal (például egy Excel munkalap). Ezeket másképp tárolják és kezelik, és különböző tulajdonsági modellel rendelkeznek.

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölőket és metaadatokat; azonban az események és makrók csak a Windows PowerPoint programon belül futnak, ha a biztonsági beállítások ezt engedélyezik. A könyvtár nem hajt végre VBA-t.