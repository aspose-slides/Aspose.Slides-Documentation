---
title: Spravujte ActiveX ovládací prvky v prezentacích pomocí Pythonu
linktitle: ActiveX
type: docs
weight: 80
url: /cs/python-net/activex/
keywords:
- ActiveX
- ActiveX ovládací prvek
- správa ActiveX
- přidání ActiveX
- úprava ActiveX
- mediální přehrávač
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak Aspose.Slides pro Python přes .NET využívá ActiveX k automatizaci a vylepšení PowerPoint prezentací a poskytuje vývojářům silnou kontrolu nad snímky."
---
## **Úvod**

ActiveX ovládací prvky se používají v prezentacích. Aspose.Slides pro Python přes .NET vám umožňuje spravovat ActiveX ovládací prvky, ale jejich správa je o něco obtížnější a liší se od běžných tvarů v prezentaci. Od verze Aspose.Slides pro Python přes .NET 6.9.0 komponenta podporuje správu ActiveX ovládacích prvků. V současné době můžete v prezentaci přistupovat k již přidanému ActiveX ovládacímu prvku a pomocí jeho různých vlastností jej upravit nebo smazat. Pamatujte, že ActiveX ovládací prvky nejsou tvary a nejsou součástí IShapeCollection prezentace, ale patří do samostatné IControlCollection. Tento článek ukazuje, jak s nimi pracovat.

## **Úprava ActiveX ovládacích prvků**
1. Vytvořte instanci třídy Presentation a načtěte prezentaci, která obsahuje ActiveX ovládací prvky.
1. Získejte odkaz na snímek pomocí jeho indexu.
1. Přistupujte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.
1. Získejte přístup k ActiveX ovládacímu prvku TextBox1 pomocí objektu ControlEx.
1. Změňte různé vlastnosti ActiveX ovládacího prvku TextBox1, včetně textu, písma, výšky písma a pozice rámce.
1. Získejte přístup k druhému ovládacímu prvku s názvem CommandButton1.
1. Změňte popisek tlačítka, písmo a pozici.
1. Posuňte polohu rámců ActiveX ovládacích prvků.
1. Uložte upravenou prezentaci do souboru PPTX.

Níže uvedený úryvek kódu aktualizuje ActiveX ovládací prvky na snímcích prezentace podle snímku zobrazeného níže.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Přístup k prezentaci s ActiveX ovládacími prvky
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Přístup k prvnímu snímku v prezentaci
    slide = presentation.slides[0]

    # měnění textu TextBoxu
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # měnění náhradního obrázku. PowerPoint tento obrázek nahradí během aktivace ActiveX, takže někdy je v pořádku nechat obrázek beze změny.

        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            # font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                graphics.draw_string(newText, font, brush, 10, 4)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, [
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [
                        draw.PointF(1, bmp.height - 1), 
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1)])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen,
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)

    # měnění popisku tlačítka
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # měnění náhrady
        bmp = draw.Bitmap(control.frame.width, control.frame.height)
        with draw.Graphics.from_image(bmp) as graphics:
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.CONTROL)) as brush:
                graphics.fill_rectangle(brush, 0, 0, bmp.width, bmp.height)

            #font = draw.Font(control.properties["FontName"], 14)
            font = draw.Font("Arial", 14)
            with draw.SolidBrush(draw.Color.from_known_color(draw.KnownColor.WINDOW_TEXT)) as brush:
                textSize = graphics.measure_string(newCaption, font, 65535)
                graphics.draw_string(newCaption, font, brush, 
                    (bmp.width - textSize.width) / 2, 
                    (bmp.height - textSize.height) / 2)

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height - 1), 
                        draw.PointF(0, 0), 
                        draw.PointF(bmp.width - 1, 0) ])
            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_LIGHT), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 2), 
                        draw.PointF(1, 1), 
                        draw.PointF(bmp.width - 2, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, bmp.height - 1),
                        draw.PointF(bmp.width - 1, 1) ])

            with draw.Pen(draw.Color.from_known_color(draw.KnownColor.CONTROL_DARK_DARK), 1) as pen:
                graphics.draw_lines(pen, 
                    [ 
                        draw.PointF(0, bmp.height), 
                        draw.PointF(bmp.width, bmp.height), 
                        draw.PointF(bmp.width, 0) ])

        bmp_bytes = io.BytesIO()
        bmp.save(bmp_bytes, drawing.imaging.ImageFormat.png)
        control.substitute_picture_format.picture.image = presentation.images.add_image(bmp_bytes)
    
    # Posunutí rámců ActiveX o 100 bodů dolů
    for ctl in slide.controls:
        frame = control.frame
        control.frame = slides.ShapeFrame(
            frame.x, 
            frame.y + 100, 
            frame.width, 
            frame.height, 
            frame.flip_h, 
            frame.flip_v, 
            frame.rotation)

    # Uložení prezentace s upravenými ActiveX ovládacími prvky
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Odstraňování ovládacích prvků
    slide.controls.clear()

    # Ukládání prezentace s vymazanými ActiveX ovládacími prvky
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Přidání ActiveX Media Player ovládacího prvku**
1. Vytvořte instanci třídy Presentation a načtěte ukázkovou prezentaci, která obsahuje Media Player ActiveX ovládací prvky.
1. Vytvořte instanci cílové třídy Presentation a vytvořte prázdnou prezentaci.
1. Zkopírujte snímek s Media Player ActiveX ovládacím prvkem ze šablonové prezentace do cílové prezentace.
1. Získejte přístup ke zkopírovanému snímku v cílové prezentaci.
1. Přistupujte k ActiveX ovládacím prvkům na snímku pomocí IControlCollection.
1. Získejte přístup k Media Player ActiveX ovládacímu prvku a pomocí jeho vlastností nastavte cestu k videu.
1. Uložte prezentaci do souboru PPTX.

```py
import aspose.slides as slides

# Vytvořte instanci třídy Presentation, která představuje soubor PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Vytvořte prázdnou instanci prezentace
    with slides.Presentation() as newPresentation:

        # Odstraňte výchozí snímek
        newPresentation.slides.remove_at(0)

        # Zduplikujte snímek s Media Player ActiveX ovládacím prvkem
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Získejte Media Player ActiveX ovládací prvek a nastavte cestu k videu
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Uložte prezentaci
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**Uchovává Aspose.Slides ActiveX ovládací prvky při načítání a opětovném uložení, pokud nelze spustit v prostředí Python?**

Ano. Aspose.Slides je považuje za součást prezentace a může číst/ upravovat jejich vlastnosti a rámečky; není nutné spouštět samotné ovládací prvky, aby byly zachovány.

**Jak se ActiveX ovládací prvky liší od OLE objektů v prezentaci?**

ActiveX ovládací prvky jsou interaktivní řízené prvky (tlačítka, textová pole, media player), zatímco [OLE](/slides/cs/python-net/manage-ole/) odkazuje na vložené aplikační objekty (například list Excelu). Jsou uloženy a zpracovávány odlišně a mají jiný model vlastností.

**Fungují události ActiveX a VBA makra, pokud byl soubor upraven pomocí Aspose.Slides?**

Aspose.Slides zachovává stávající značkování a metadata; události a makra však běží pouze v PowerPointu na Windows, pokud to bezpečnostní nastavení povolí. Knihovna nevykonává VBA.