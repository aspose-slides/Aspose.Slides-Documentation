---
title: Správa ActiveX ovládacích prvků v prezentacích pomocí Pythonu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/python-java/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- přehrávač médií
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro Python přes Java využívá ActiveX k automatizaci a vylepšení PowerPoint prezentací, což vývojářům poskytuje silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro Python přes Java umožňuje přidávat a spravovat ActiveX ovládací prvky, ale jsou o něco obtížnější na správu ve srovnání s běžnými tvary v prezentaci. Aspose.Slides podporuje přidávání ActiveX ovládacích prvků Media Player. Všimněte si, že ActiveX ovládací prvky nejsou tvary; nejsou součástí prezentace [ShapeCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/shapecollection/). Jsou součástí samostatné [ControlCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/controlcollection/) místo toho. V tomto tématu vám ukážeme, jak s nimi pracovat.

## **Přidání ActiveX ovládacího prvku Media Player na snímek**

Chcete‑li přidat ActiveX ovládací prvek Media Player, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a vytvořte prázdnou prezentaci.
2. Získejte cílový snímek v [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
3. Přidejte ActiveX ovládací prvek Media Player pomocí metody [addControl](https://reference.aspose.com/slides/cs/python-java/aspose.slides/controlcollection/#addControl) zveřejněné v [ControlCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/controlcollection/).
4. Získejte přístup k ActiveX ovládacímu prvku Media Player a nastavte cestu k videu pomocí jeho vlastností.
5. Uložte prezentaci jako soubor PPTX.

Tento ukázkový kód, založený na výše uvedených krocích, ukazuje, jak přidat ActiveX ovládací prvek Media Player na snímek:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ControlType, Presentation, SaveFormat

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    # Přidejte ActiveX ovládací prvek Media Player.
    slide = presentation.getSlides().get_Item(0)
    control = slide.getControls().addControl(ControlType.WindowsMediaPlayer, 100, 100, 400, 400)

    # Nastavte cestu k videu.
    control.getProperties().set_Item("URL", "Wildlife.wmv")

    # Uložte prezentaci.
    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Úprava ActiveX ovládacího prvku**

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides pro Python přes Java poskytuje komponenty pro správu ActiveX ovládacích prvků. Můžete získat přístup k již přidanému ActiveX ovládacímu prvku ve vaší prezentaci a upravit jej nebo smazat pomocí jeho vlastností.
{{% /alert %}}

Pro správu jednoduchého ActiveX ovládacího prvku, jako je textové pole a jednoduché tlačítko příkazu na snímku, proveďte následující:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
2. Získejte referenci na snímek podle jeho indexu.
3. Získejte přístup k ActiveX ovládacím prvkům na snímku pomocí [ControlCollection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/controlcollection/).
4. Získejte přístup k ActiveX ovládacímu prvku TextBox1 pomocí objektu [Control](https://reference.aspose.com/slides/cs/python-java/aspose.slides/control/).
5. Změňte vlastnosti ActiveX ovládacího prvku TextBox1, které zahrnují text, písmo, výšku písma a pozici rámce.
6. Získejte přístup ke druhému ActiveX ovládacímu prvku nazvanému CommandButton1.
7. Změňte popisek tlačítka, písmo a pozici.
8. Posuňte pozici rámců ActiveX ovládacích prvků.
9. Uložte upravenou prezentaci do souboru PPTM.

Tento ukázkový kód, založený na výše uvedených krocích, ukazuje, jak spravovat jednoduchý ActiveX ovládací prvek:

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

# Načtěte prezentaci s ActiveX ovládacími prvky.
presentation = Presentation("ActiveX.pptm")
try:
    if presentation.getSlides().size() > 0 and presentation.getSlides().get_Item(0).getControls().size() >= 2:
        # Získejte přístup k prvnímu snímku.
        slide = presentation.getSlides().get_Item(0)

        # Změňte text v textovém poli.
        control = slide.getControls().get_Item(0)

        if str(control.getName()).lower() == "textbox1" and control.getProperties() is not None:
            new_text = "Changed text"
            control.getProperties().set_Item("Value", new_text)

            # Změňte náhradní obrázek. PowerPoint jej během aktivace ActiveX nahradí,
            # takže jej lze někdy nechat nezměněný.
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

        # Změňte popisek tlačítka.
        control = presentation.getSlides().get_Item(0).getControls().get_Item(1)

        if str(control.getName()).lower() == "commandbutton1" and control.getProperties() is not None:
            new_caption = "Show MessageBox"
            control.getProperties().set_Item("Caption", new_caption)
            # Změňte náhradní obrázek.
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

        # Posuňte ovládací prvky dolů o 100 bodů.
        for control in slide.getControls():
            frame = control.getFrame()
            new_frame = ShapeFrame(frame.getX(), frame.getY() + 100, frame.getWidth(), frame.getHeight(), frame.getFlipH(), frame.getFlipV(), frame.getRotation())
            control.setFrame(new_frame)
        presentation.save("withActiveX-edited_python.pptm", SaveFormat.Pptm)

        # Odstraňte ovládací prvky.
        presentation.getSlides().get_Item(0).getControls().clear()
        presentation.save("withActiveX-cleared_python.pptm", SaveFormat.Pptm)
    else:
        print("The first slide must contain the TextBox1 and CommandButton1 ActiveX controls.")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Zachovává Aspose.Slides ActiveX ovládací prvky při čtení a opětovném uložení, pokud nemohou být spuštěny v Python runtime?**

Ano. Aspose.Slides je považuje za součást prezentace a může číst/upravovat jejich vlastnosti a rámce; k jejich zachování není nutné spouštět samotné ovládací prvky.

**Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?**

ActiveX ovládací prvky jsou interaktivní spravované ovládací prvky (tlačítka, textová pole, přehrávač médií), zatímco [OLE](/slides/cs/python-java/manage-ole/) označuje vložené objekty aplikací (například list Excelu). Jsou ukládány a zpracovávány odlišně a mají jiný model vlastností.

**Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**

Aspose.Slides zachovává existující značkování a metadata; avšak události a makra se spouští pouze v PowerPointu na Windows, pokud to bezpečnost povolí. Knihovna nevykonává VBA.