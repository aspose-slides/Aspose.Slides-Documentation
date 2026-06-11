---
title: "Zarządzanie kontrolkami ActiveX w prezentacjach na Androidzie"
linktitle: "ActiveX"
type: docs
weight: 80
url: /pl/androidjava/activex/
keywords:
- "ActiveX"
- "kontrolka ActiveX"
- "zarządzanie ActiveX"
- "dodawanie ActiveX"
- "modyfikowanie ActiveX"
- "odtwarzacz multimedialny"
- "PowerPoint"
- "prezentacja"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Dowiedz się, jak Aspose.Slides for Android via Java wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, zapewniając programistom potężną kontrolę nad slajdami."
---
## **Wstęp**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides for Android via Java umożliwia dodawanie i zarządzanie kontrolkami ActiveX, ale są one nieco trudniejsze w obsłudze w porównaniu do zwykłych kształtów w prezentacji. Wdrożyliśmy obsługę dodawania kontrolki Media Player Active w Aspose.Slides. Należy zauważyć, że kontrolki ActiveX nie są kształtami; nie są częścią prezentacji [IShapeCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/). Są częścią odrębnego [IControlCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrolcollection/) zamiast tego. W tym temacie pokażemy, jak z nimi pracować.

## **Dodaj kontrolkę ActiveX Media Player do slajdu**
Aby dodać kontrolkę ActiveX Media Player, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wygeneruj pustą prezentację.
2. Uzyskaj dostęp do docelowego slajdu w [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
3. Dodaj kontrolkę Media Player ActiveX przy użyciu metody [addControl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IControlCollection#addControl-int-float-float-float-float-) udostępnionej przez [IControlCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrolcollection/).
4. Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo, używając jej właściwości.
5. Zapisz prezentację jako plik PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak dodać kontrolkę Media Player ActiveX do slajdu:

```java
// Utwórz pustą instancję prezentacji
Presentation pres = new Presentation();
try {
    // Dodawanie kontrolki ActiveX Media Player
    pres.getSlides().get_Item(0).getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400);

    // Uzyskaj dostęp do kontrolki ActiveX Media Player i ustaw ścieżkę wideo
    pres.getSlides().get_Item(0).getControls().get_Item(0).getProperties().set_Item("URL", "Wildlife.wmv");

    // Zapisz prezentację
    pres.save("Output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Modyfikowanie kontrolki ActiveX**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java 7.1.0 i nowsze wersje są wyposażone w komponenty do zarządzania kontrolkami ActiveX. Możesz uzyskać dostęp do już dodanej kontrolki ActiveX w swojej prezentacji i modyfikować lub usuwać ją za pomocą jej właściwości.

{{% /alert %}} 

Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk poleceń na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation) i wczytaj prezentację zawierającą kontrolki ActiveX.
2. Uzyskaj odniesienie do slajdu na podstawie jego indeksu.
3. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do [IControlCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrolcollection/).
4. Uzyskaj dostęp do kontrolki ActiveX TextBox1 przy użyciu obiektu [IControl](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/icontrol/).
5. Zmień właściwości kontrolki ActiveX TextBox1, takie jak tekst, czcionka, wysokość czcionki i pozycja ramki.
6. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
7. Zmień podpis przycisku, czcionkę i pozycję.
8. Przesuń pozycję ramek kontrolek ActiveX.
9. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak zarządzać prostą kontrolką ActiveX:

```java
// Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
Presentation pres = new Presentation("ActiveX.pptm");
try {
    // Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // zmiana tekstu TextBox
    IControl control = slide.getControls().get_Item(0);

    if (control.getName().equalsIgnoreCase("TextBox1") && control.getProperties() != null) {
        String newText = "Changed text";
        control.getProperties().set_Item("Value", newText);

        // Zmiana obrazu zastępczego. PowerPoint zastąpi ten obraz podczas aktywacji ActiveX,
        // więc czasami można zostawić obraz niezmieniony.
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);

        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.window);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        graphics.drawString(newText, 10, 20);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlDkShadow);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
        graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

        graphics.dispose();

        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        ImageIO.write(image, "PNG", baos);

        control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
    }

    // Zmiana podpisu przycisku
    control = pres.getSlides().get_Item(0).getControls().get_Item(1);

    if (control.getName().equalsIgnoreCase("CommandButton1") && control.getProperties() != null) {
        String newCaption = "Show MessageBox";
        control.getProperties().set_Item("Caption", newCaption);
        // Zmiana obrazu zastępczego
        BufferedImage image = new BufferedImage((int) control.getFrame().getWidth(), (int) control.getFrame().getHeight(),
                BufferedImage.TYPE_INT_ARGB);
        java.awt.Graphics graphics = image.getGraphics();
        graphics.setColor(SystemColor.control);
        graphics.fillRect(0, 0, image.getWidth(), image.getHeight());

        java.awt.Font font = new java.awt.Font(control.getProperties().get_Item("FontName"), java.awt.Font.PLAIN, 16);
        graphics.setColor(SystemColor.windowText);
        graphics.setFont(font);
        FontMetrics metrics = graphics.getFontMetrics(font);
        graphics.drawString(newCaption, (image.getWidth() - metrics.stringWidth(newCaption)) / 2, 20);

        graphics.setColor(SystemColor.controlLtHighlight);
        graphics.drawLine(0, image.getHeight() - 1, 0, 0);
        graphics.drawLine(0, 0, image.getWidth() - 1, 0);

        graphics.setColor(SystemColor.controlHighlight);
        graphics.drawLine(1, image.getHeight() - 2, 1, 1);
        graphics.drawLine(1, 1, image.getWidth() - 2, 1);

        graphics.setColor(SystemColor.controlShadow);
        graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1);
        graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1);

        graphics.setColor(SystemColor.controlDkShadow);
                graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight());
                graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0);

                graphics.dispose();

                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ImageIO.write(image, "PNG", baos);

                control.getSubstitutePictureFormat().getPicture().setImage(pres.getImages().addImage(baos.toByteArray()));
            }

            // przesunięcie w dół o 100 punktów
            for (IControl ctl : pres.getSlides().get_Item(0).getControls()) {
                IShapeFrame frame = ctl.getFrame();
                ctl.setFrame(new ShapeFrame(frame.getX(), frame.getY() + 100,
                        frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation()));
            }
            pres.save("withActiveX-edited_java.pptm", SaveFormat.Pptm);

            // usuwanie kontrolek
            pres.getSlides().get_Item(0).getControls().clear();
            pres.save("withActiveX-cleared_java.pptm", SaveFormat.Pptm);
        } catch(IOException e) {
        } finally {
            if (pres != null) pres.dispose();
        }
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX podczas odczytu i ponownego zapisu, jeśli nie mogą być wykonywane w środowisku Java?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości oraz ramki; wykonywanie samych kontrolek nie jest wymagane do ich zachowania.

**Jak kontrolki ActiveX różnią się od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi, zarządzanymi kontrolkami (przyciski, pola tekstowe, odtwarzacz multimedialny), podczas gdy [OLE](/slides/pl/androidjava/manage-ole/) odnosi się do osadzonych obiektów aplikacji (na przykład arkusza Excel). Są przechowywane i obsługiwane inaczej oraz mają inny model właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejące znaczniki i metadane; jednak zdarzenia i makra działają tylko w programie PowerPoint na systemie Windows, gdy pozwala na to zabezpieczenie. Biblioteka nie wykonuje kodu VBA.