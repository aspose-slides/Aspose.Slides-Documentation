---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu JavaScript
linktitle: ActiveX
type: docs
weight: 80
url: /pl/nodejs-java/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for Node.js via Java wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, dając programistom potężną kontrolę nad slajdami."
---
## **Wprowadzenie**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides for Node.js via Java umożliwia dodawanie i zarządzanie kontrolkami ActiveX, ale są one nieco trudniejsze w obsłudze w porównaniu do zwykłych kształtów prezentacji. Dodaliśmy obsługę dodawania kontrolki Media Player Active w Aspose.Slides. Należy zauważyć, że kontrolki ActiveX nie są kształtami; nie są częścią prezentacji [ShapeCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/). Są częścią oddzielnego [ControlCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/controlcollection/) zamiast tego. W tym temacie pokażemy, jak z nimi pracować.

## **Dodawanie kontrolki Media Player ActiveX do slajdu**
Aby dodać kontrolkę Media Player ActiveX, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i wygeneruj pustą prezentację.
1. Uzyskaj dostęp do docelowego slajdu w [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
1. Dodaj kontrolkę Media Player ActiveX przy użyciu metody [addControl](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/ControlCollection#addControl-int-float-float-float-float-) udostępnionej przez [ControlCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/controlcollection/).
1. Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo, korzystając z jej właściwości.
1. Zapisz prezentację jako plik PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak dodać kontrolkę Media Player ActiveX do slajdu:

```javascript
// Utwórz pustą instancję prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Dodawanie kontrolki Media Player ActiveX
    pres.getSlides().get_Item(0).getControls().addControl(aspose.slides.ControlType.WindowsMediaPlayer, 100, 100, 400, 400);
    // Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("java.net.URL", "Wildlife.wmv");
    // Zapisz prezentację
    pres.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Modyfikowanie kontrolki ActiveX**

Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk polecenia na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation) i załaduj prezentację zawierającą kontrolki ActiveX.
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do [ControlCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/controlcollection/).
1. Uzyskaj dostęp do kontrolki ActiveX TextBox1 przy użyciu obiektu [Control](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/control/).
1. Zmień właściwości kontrolki ActiveX TextBox1, w tym tekst, czcionkę, wysokość czcionki oraz położenie ramki.
1. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
1. Zmień etykietę przycisku, czcionkę i położenie.
1. Przesuń położenie ramek kontrolek ActiveX.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak zarządzać prostą kontrolką ActiveX:

```javascript
const imageio = java.import("javax.imageio.ImageIO");
// Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
var pres = new aspose.slides.Presentation("ActiveX.pptm");
try {
    // Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
    var slide = pres.getSlides().get_Item(0);
    // zmiana tekstu TextBox
    var control = slide.getControls().get_Item(0);
    if (control.getName().toUpperCase() === "TextBox1".toUpperCase() && (control.getProperties() != null)) {
        var newText = "Changed text";
        control.getProperties().set_Item("Value", newText);
        // Zmienianie obrazu zastępczego. PowerPoint zastąpi ten obraz podczas aktywacji ActiveX,
        // więc czasami można pozostawić obraz niezmieniony.
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
    // Zmienianie podpisu przycisku
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);
    if (control.getName().toUpperCase() === "CommandButton1".toUpperCase() && (control.getProperties() != null)) {
        var newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Zmienianie obrazu zastępczego
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
    // przesuwanie o 100 punktów w dół
    for (let i = 0; i < pres.getSlides().get_Item(0).getControls().size(); i++) {
        let ctl = pres.getSlides().get_Item(0).getControls().get_Item(i);
        var frame = ctl.getFrame();
        ctl.setFrame(new aspose.slides.ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), java.newByte(frame.getFlipH()), java.newByte(frame.getFlipV()), frame.getRotation()));
    }
    pres.save("withActiveX-edited_java.pptm", aspose.slides.SaveFormat.Pptm);
    // usuwanie kontrolek
    pres.getSlides().get_Item(0).getControls().clear();
    pres.save("withActiveX-cleared_java.pptm", aspose.slides.SaveFormat.Pptm);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX przy odczycie i ponownym zapisie, jeśli nie mogą być uruchomione w środowisku Python?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości oraz ramki; uruchamianie samych kontrolek nie jest wymagane, aby je zachować.

**Czym kontrolki ActiveX różnią się od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi, zarządzanymi kontrolkami (przyciski, pola tekstowe, odtwarzacz multimedialny), podczas gdy [OLE](/slides/pl/nodejs-java/manage-ole/) odnosi się do osadzonych obiektów aplikacji (np. arkusz Excel). Są przechowywane i obsługiwane inaczej oraz mają inny model właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejące znaczniki i metadane; jednak zdarzenia i makra uruchamiane są jedynie w programie PowerPoint na systemie Windows, gdy zabezpieczenia na to pozwalają. Biblioteka nie wykonuje kodu VBA.