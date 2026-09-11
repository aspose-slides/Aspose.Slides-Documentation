---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy użyciu Pythona
linktitle: ActiveX
type: docs
weight: 80
url: /pl/python-java/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikowanie ActiveX
- odtwarzacz multimedialny
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides for Python via Java wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, dając programistom potężną kontrolę nad slajdami."
---
## **Wprowadzenie**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides for Python via Java umożliwia dodawanie i zarządzanie kontrolkami ActiveX, ale są one nieco trudniejsze w obsłudze w porównaniu do standardowych kształtów prezentacji. Aspose.Slides obsługuje dodawanie kontrolek Media Player ActiveX. Należy zauważyć, że kontrolki ActiveX nie są kształtami; nie są częścią prezentacji [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/). Należą do osobnej [ControlCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/controlcollection/) zamiast tego. W tym temacie pokażemy, jak z nimi pracować.

## **Dodaj kontrolkę Media Player ActiveX do slajdu**

Aby dodać kontrolkę Media Player ActiveX, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), aby wygenerować pustą prezentację.
2. Uzyskaj dostęp do docelowego slajdu w [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
3. Dodaj kontrolkę Media Player ActiveX przy użyciu metody [addControl](https://reference.aspose.com/slides/pl/python-java/aspose.slides/controlcollection/#addControl), udostępnionej przez [ControlCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/controlcollection/).
4. Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo, korzystając z jej właściwości.
5. Zapisz prezentację jako plik PPTX.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak dodać kontrolkę Media Player ActiveX do slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    # Dodaj kontrolkę Media Player ActiveX.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Ustaw ścieżkę wideo.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Zapisz prezentację.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Modyfikuj kontrolkę ActiveX**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java udostępnia komponenty do zarządzania kontrolkami ActiveX. Możesz uzyskać dostęp do już dodanej kontrolki ActiveX w swojej prezentacji i modyfikować lub usuwać ją za pomocą jej właściwości.
{{% /alert %}}

Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk poleceń na slajdzie, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/), a następnie załaduj prezentację zawierającą kontrolki ActiveX.
2. Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
3. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do [ControlCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/controlcollection/).
4. Uzyskaj dostęp do kontrolki ActiveX TextBox1, używając obiektu [Control](https://reference.aspose.com/slides/pl/python-java/aspose.slides/control/).
5. Zmień właściwości kontrolki ActiveX TextBox1, takie jak tekst, czcionka, wysokość czcionki oraz położenie ramki.
6. Uzyskaj dostęp do drugiej kontrolki ActiveX o nazwie CommandButton1.
7. Zmień etykietę przycisku, czcionkę i położenie.
8. Przesuń położenie ramek kontrolek ActiveX.
9. Zapisz zmodyfikowaną prezentację do pliku PPTM.

Ten przykładowy kod, oparty na powyższych krokach, pokazuje, jak zarządzać prostą kontrolką ActiveX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeFrame
from java.awt import Font, SystemColor
from java.awt.image import BufferedImage
from java.io import ByteArrayOutputStream
from javax.imageio import ImageIO

# Załaduj prezentację z kontrolkami ActiveX.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Uzyskaj dostęp do pierwszego slajdu.
        slide = presentation.getSlides().get_Item(0)

        # Zmień tekst pola tekstowego.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Zmień obraz zastępczy. PowerPoint zamienia go podczas aktywacji ActiveX,
            # dlatego może czasami pozostać niezmieniony.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)

            graphics = image.getGraphics()
            graphics.setColor(SystemColor.window)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            graphics.drawString(new_text, 10, 20)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Zmień etykietę przycisku.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Zmień obraz zastępczy.
            image = BufferedImage(int(control.getFrame().getWidth()), int(control.getFrame().getHeight()), BufferedImage.TYPE_INT_ARGB)
            graphics = image.getGraphics()
            graphics.setColor(SystemColor.control)
            graphics.fillRect(0, 0, image.getWidth(), image.getHeight())

            font = Font(control.getProperties().get_Item("FontName"), Font.PLAIN, 16)
            graphics.setColor(SystemColor.windowText)
            graphics.setFont(font)
            metrics = graphics.getFontMetrics(font)
            graphics.drawString(new_caption, (image.getWidth() - metrics.stringWidth(new_caption)) // 2, 20)

            graphics.setColor(SystemColor.controlLtHighlight)
            graphics.drawLine(0, image.getHeight() - 1, 0, 0)
            graphics.drawLine(0, 0, image.getWidth() - 1, 0)

            graphics.setColor(SystemColor.controlHighlight)
            graphics.drawLine(1, image.getHeight() - 2, 1, 1)
            graphics.drawLine(1, 1, image.getWidth() - 2, 1)

            graphics.setColor(SystemColor.controlShadow)
            graphics.drawLine(1, image.getHeight() - 1, image.getWidth() - 1, image.getHeight() - 1)
            graphics.drawLine(image.getWidth() - 1, image.getHeight() - 1, image.getWidth() - 1, 1)

            graphics.setColor(SystemColor.controlDkShadow)
            graphics.drawLine(0, image.getHeight(), image.getWidth(), image.getHeight())
            graphics.drawLine(image.getWidth(), image.getHeight(), image.getWidth(), 0)

            graphics.dispose()

            image_stream = ByteArrayOutputStream()
            ImageIO.write(image, "PNG", image_stream)

            image_bytes = image_stream.toByteArray()
            substitute_image = presentation.getImages().addImage(image_bytes)
            control.getSubstitutePictureFormat().getPicture().setImage(substitute_image)

        # Przesuń kontrolki w dół o 100 punktów.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Usuń kontrolki.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX podczas odczytu i ponownego zapisu, jeśli nie mogą być wykonane w środowisku uruchomieniowym Pythona?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości oraz ramki; nie jest wymagane uruchamianie samych kontrolek, aby je zachować.

**Czym różnią się kontrolki ActiveX od obiektów OLE w prezentacji?**

Kontrolki ActiveX są interaktywnymi kontrolkami zarządzanymi (przyciski, pola tekstowe, odtwarzacz multimediów), natomiast [OLE](/slides/pl/python-java/manage-ole/) odnosi się do osadzonych obiektów aplikacji (na przykład arkusza Excel). Są przechowywane i obsługiwane inaczej oraz posiadają odrębne modele właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejący znacznik i metadane; jednak zdarzenia i makra działają wyłącznie w PowerPoint na systemie Windows, gdy pozwala na to zabezpieczenie. Biblioteka nie wykonuje VBA.