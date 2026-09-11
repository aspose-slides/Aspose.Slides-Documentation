---
title: ActiveX vezérlők kezelése prezentációkban Python használatával
linktitle: ActiveX
type: docs
weight: 80
url: /hu/python-java/activex/
keywords:
- ActiveX
- ActiveX vezérlő
- ActiveX kezelése
- ActiveX hozzáadása
- ActiveX módosítása
- médialejátszó
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for Python via Java az ActiveX-et a PowerPoint prezentációk automatizálásához és fejlesztéséhez, erőteljes vezérlést biztosítva a fejlesztőknek a diák felett."
---
## **Bevezetés**

Az ActiveX vezérlőket prezentációkban használják. Az Aspose.Slides for Python via Java lehetővé teszi ActiveX vezérlők hozzáadását és kezelését, de ezek kezelése egy kicsit nehezebb a szokásos prezentációs alakzatokhoz képest. Az Aspose.Slides támogatja a Media Player ActiveX vezérlők hozzáadását. Vegye figyelembe, hogy az ActiveX vezérlők nem alakzatok; nem részei a prezentáció [ShapeCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/shapecollection/). Ezek a különálló [ControlCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/controlcollection/) részei. Ebben a témában megmutatjuk, hogyan dolgozhat velük.

## **Media Player ActiveX vezérlő hozzáadása diára**

Az ActiveX Media Player vezérlő hozzáadásához tegye a következőket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és generáljon egy üres prezentációt.
2. Érje el a cél diát a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) segítségével.
3. Adja hozzá a Media Player ActiveX vezérlőt a [ControlCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/controlcollection/)-ben elérhető [addControl](https://reference.aspose.com/slides/hu/python-java/aspose.slides/controlcollection/#addControl) metódus használatával.
4. Érje el a Media Player ActiveX vezérlőt, és állítsa be a videó útvonalát a tulajdonságainak használatával.
5. Mentse a prezentációt PPTX fájlként.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Hozzon létre egy üres prezentációt.
presentation = Presentation()
try:
    # Adja hozzá a Media Player ActiveX vezérlőt.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Állítsa be a videó útvonalát.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Mentse a prezentációt.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ActiveX vezérlő módosítása**

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for Python via Java komponenseket biztosít az ActiveX vezérlők kezeléséhez. Elérheti a már hozzáadott ActiveX vezérlőt a prezentációban, és módosíthatja vagy törölheti a tulajdonságain keresztül.
{{% /alert %}}

Egy egyszerű ActiveX vezérlő, például egy szövegmező és egy egyszerű parancsgomb kezelése egy dián a következőképpen történik:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból, és töltse be a benne ActiveX vezérlőket tartalmazó prezentációt.
2. Szerezzen be egy diára mutató hivatkozást az indexe alapján.
3. Érje el a dián lévő ActiveX vezérlőket a [ControlCollection](https://reference.aspose.com/slides/hu/python-java/aspose.slides/controlcollection/) elérésével.
4. A [Control](https://reference.aspose.com/slides/hu/python-java/aspose.slides/control/) objektum használatával érje el a TextBox1 ActiveX vezérlőt.
5. Módosítsa a TextBox1 ActiveX vezérlő tulajdonságait, beleértve a szöveget, betűtípust, betűmagasságot és a keret pozícióját.
6. Érje el a második, CommandButton1 nevű ActiveX vezérlőt.
7. Módosítsa a gomb feliratát, betűtípust és pozíciót.
8. Módosítsa az ActiveX vezérlők kereteinek pozícióját.
9. Írja a módosított prezentációt PPTM fájlba.

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

# Töltsük be a prezentációt ActiveX vezérlőkkel.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Hozzáférés az első diahoz.
        slide = presentation.getSlides().get_Item(0)

        # Módosítsuk a szövegmező szövegét.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Cserélje le a helyettesítő képet. A PowerPoint az ActiveX aktiválásakor cseréli ki,
            # ezért előfordulhat, hogy változatlan marad.
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

        # Módosítsuk a gomb feliratát.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Cserélje le a helyettesítő képet.
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

        # Mozgassa le a vezérlőket 100 ponttal.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Távolítsa el a vezérlőket.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **GYIK**

**Megőrzi az Aspose.Slides az ActiveX vezérlőket olvasáskor és újra mentéskor, ha nem futtathatók a Python futtatókörnyezetben?**

Igen. Az Aspose.Slides ezeket a prezentáció részének tekinti, és képes olvasni/módosítani a tulajdonságaikat és kereteiket; a vezérlők tényleges végrehajtása nem szükséges a megőrzésükhöz.

**Miben különböznek az ActiveX vezérlők az OLE objektumoktól egy prezentációban?**

Az ActiveX vezérlők interaktív, kezelt vezérlők (gombok, szövegmezők, média lejátszó), míg az [OLE](/slides/hu/python-java/manage-ole/) beágyazott alkalmazásobjektumokra (például Excel-munkalap) utal. Másként tárolják és kezelik őket, és különböző tulajdonságmodellel rendelkeznek.

**Működnek az ActiveX események és VBA makrók, ha a fájlt az Aspose.Slides módosította?**

Az Aspose.Slides megőrzi a meglévő jelölőket és metaadatokat; azonban az események és makrók csak a Windows PowerPoint programban futnak, ha a biztonsági beállítások engedik. A könyvtár nem hajtja végre a VBA-t.