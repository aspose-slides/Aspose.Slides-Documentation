---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí JavaScriptu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/nodejs-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- spravovat ActiveX
- přidat ActiveX
- upravit ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak Aspose.Slides pro Node.js přes Java využívá ActiveX k automatizaci a vylepšení PowerPoint prezentací, poskytující vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro Node.js přes Java vám umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jsou o něco obtížnější na správu ve srovnání s běžnými tvary v prezentaci. Implementovali jsme podporu pro přidání aktivního ovládacího prvku Media Player v Aspose.Slides. Všimněte si, že ActiveX ovládací prvky nejsou tvary; nejsou součástí prezentace [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shapecollection/). Jsou součástí samostatného [ControlCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/controlcollection/) místo toho. V tomto tématu vám ukážeme, jak s nimi pracovat.

## **Přidání ActiveX ovládacího prvku Media Player na snímek**
Chcete-li přidat ovládací prvek ActiveX Media Player, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a vygenerujte prázdnou prezentaci.
2. Získejte cílový snímek v [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation).
3. Přidejte ovládací prvek Media Player ActiveX pomocí metody [addControl](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) vystavené třídou [ControlCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/controlcollection/).
4. Získejte ovládací prvek Media Player ActiveX a nastavte cestu k videu pomocí jeho vlastností.
5. Uložte prezentaci jako soubor PPTX.

Ukázkový kód níže, založený na výše uvedených krocích, ukazuje, jak přidat ovládací prvek Media Player ActiveX na snímek:

```javascript
// Vytvořte prázdnou instanci prezentace
var pres = new aspose.slides.Presentation();
try {
    // Přidání ActiveX ovládacího prvku Media Player
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Získejte přístup k ActiveX ovládacímu prvku Media Player a nastavte cestu k videu
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Uložte prezentaci
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Úprava ActiveX ovládacího prvku**

Aby bylo možné spravovat jednoduchý ActiveX ovládací prvek, jako je textové pole a jednoduché tlačítko příkazu na snímku, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation) a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
2. Získejte odkaz na snímek podle jeho indexu.
3. Získejte ActiveX ovládací prvky na snímku přístupem k [ControlCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/controlcollection/).
4. Získejte ActiveX ovládací prvek TextBox1 pomocí objektu [Control](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/control/).
5. Změňte vlastnosti ActiveX ovládacího prvku TextBox1, které zahrnují text, písmo, výšku písma a pozici rámce.
6. Získejte druhý ovládací prvek nazvaný CommandButton1.
7. Změňte popisek tlačítka, písmo a pozici.
8. Posuňte pozici rámců ActiveX ovládacích prvků.
9. Zapište upravenou prezentaci do souboru PPTX.

Ukázkový kód níže, založený na výše uvedených krocích, ukazuje, jak spravovat jednoduchý ActiveX ovládací prvek: 

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Přístup k prezentaci s ActiveX ovládacími prvky
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Přístup k prvnímu snímku v prezentaci
    var slide = pres.getSlides().get_Item(0);
    // změna textu TextBoxu
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Změna náhradního obrázku. PowerPoint nahradí tento obrázek během aktivace ActiveX,
        // takže někdy je v pořádku nechat obrázek beze změny.
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
    // Změna popisku tlačítka
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Změna náhrady
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
    // posunutí o 100 bodů dolů
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // odstranění ovládacích prvků
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Uchovává Aspose.Slides ActiveX ovládací prvky při čtení a opětovném uložení, pokud nemohou být spuštěny v runtime Pythonu?**

Ano. Aspose.Slides je považuje za součást prezentace a může číst/upravovat jejich vlastnosti a rámy; není nutné spouštět samotné ovládací prvky k jejich zachování.

**Jak se liší ActiveX ovládací prvky od OLE objektů v prezentaci?**

ActiveX ovládací prvky jsou interaktivní řízené ovládací prvky (tlačítka, textová pole, přehrávač médií), zatímco [OLE](/slides/cs/nodejs-java/manage-ole/) označuje vložené objekty aplikací (například list Excelu). Jsou ukládány a zpracovávány odlišně a mají různý model vlastností.

**Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**

Aspose.Slides zachovává existující značkování a metadata; události a makra však běží pouze v PowerPointu na Windows, pokud to bezpečnostní nastavení umožní. Knihovna nevykonává VBA.