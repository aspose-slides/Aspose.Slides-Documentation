---
title: Zarządzanie kontrolkami ActiveX w prezentacjach przy pomocy Pythona
linktitle: ActiveX
type: docs
weight: 80
url: /pl/python-net/activex/
keywords:
- ActiveX
- kontrolka ActiveX
- zarządzanie ActiveX
- dodawanie ActiveX
- modyfikacja ActiveX
- odtwarzacz multimediów
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak Aspose.Slides dla Pythona poprzez .NET wykorzystuje ActiveX do automatyzacji i ulepszania prezentacji PowerPoint, dając programistom potężną kontrolę nad slajdami."
---
## **Wprowadzenie**

Kontrolki ActiveX są używane w prezentacjach. Aspose.Slides dla Pythona poprzez .NET umożliwia zarządzanie kontrolkami ActiveX, ale ich obsługa jest nieco trudniejsza i inna niż normalne kształty w prezentacji. Od wersji Aspose.Slides dla Pythona poprzez .NET 6.9.0 komponent obsługuje zarządzanie kontrolkami ActiveX. Obecnie możesz uzyskać dostęp do już dodanej kontrolki ActiveX w swojej prezentacji i modyfikować lub usuwać ją, wykorzystując jej różne właściwości. Pamiętaj, że kontrolki ActiveX nie są kształtami i nie należą do IShapeCollection prezentacji, lecz do oddzielnego IControlCollection. Ten artykuł pokazuje, jak z nimi pracować.

## **Modyfikacja kontrolek ActiveX**
Aby zarządzać prostą kontrolką ActiveX, taką jak pole tekstowe i prosty przycisk polecenia na slajdzie:

1. Utwórz instancję klasy Presentation i załaduj prezentację zawierającą kontrolki ActiveX.
1. Uzyskaj referencję do slajdu za pomocą jego indeksu.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
1. Uzyskaj dostęp do kontrolki ActiveX TextBox1 przy użyciu obiektu ControlEx.
1. Zmień różne właściwości kontrolki ActiveX TextBox1, w tym tekst, czcionkę, wysokość czcionki oraz pozycję ramki.
1. Uzyskaj dostęp do drugiej kontrolki o nazwie CommandButton1.
1. Zmień etykietę przycisku, czcionkę oraz pozycję.
1. Przesuń położenie ramek kontrolek ActiveX.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

Poniższy fragment kodu aktualizuje kontrolki ActiveX na slajdach prezentacji, tak jak pokazano poniżej.

```py
import aspose.slides as slides
import aspose.pydrawing as draw
import io

# Uzyskiwanie dostępu do prezentacji z kontrolkami ActiveX
with slides.Presentation(path + "ActiveX.pptm") as presentation:
    # Uzyskiwanie dostępu do pierwszego slajdu w prezentacji
    slide = presentation.slides[0]

    # zmiana tekstu TextBox
    control = slide.controls[0]

    if control.name == "TextBox1" and control.properties != None:
        newText = "Changed text"
        control.properties.remove("Value")
        control.properties.add("Value", newText)

        # zmiana obrazu zastępczego. PowerPoint zastąpi ten obraz podczas aktywacji ActiveX, więc czasami można pozostawić obraz niezmieniony.

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

    # zmiana podpisu przycisku
    control = slide.controls[1]

    if control.name == "CommandButton1" and control.properties != None:
        newCaption = "MessageBox"
        control.properties.remove("Caption")
        control.properties.add("Caption", newCaption)

        # zmiana obrazu zastępczego
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
    
    # Przesuwanie ramek ActiveX o 100 punktów w dół
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

    # Zapis prezentacji z edytowanymi kontrolkami ActiveX
    presentation.save("withActiveX-edited_out.pptm", slides.export.SaveFormat.PPTM)


    # Teraz usuwanie kontrolek
    slide.controls.clear()

    # Zapis prezentacji z usuniętymi kontrolkami ActiveX
    presentation.save("withActiveX.cleared_out.pptm", slides.export.SaveFormat.PPTM)
```

## **Dodanie kontrolki ActiveX Media Player**
Aby dodać kontrolkę ActiveX Media Player, wykonaj następujące kroki:

1. Utwórz instancję klasy Presentation i załaduj przykładową prezentację zawierającą kontrolki Media Player ActiveX.
1. Utwórz instancję docelowej klasy Presentation i wygeneruj pustą prezentację.
1. Sklonuj slajd z kontrolką Media Player ActiveX z prezentacji szablonu do docelowej prezentacji.
1. Uzyskaj dostęp do sklonowanego slajdu w docelowej prezentacji.
1. Uzyskaj dostęp do kontrolek ActiveX na slajdzie, odwołując się do IControlCollection.
1. Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo, używając jej właściwości.
1. Zapisz prezentację do pliku PPTX.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation reprezentującej plik PPTX
with slides.Presentation(path + "template.pptx") as presentation:

    # Utwórz pustą instancję prezentacji
    with slides.Presentation() as newPresentation:

        # Usuń domyślny slajd
        newPresentation.slides.remove_at(0)

        # Sklonuj slajd z kontrolką Media Player ActiveX
        newPresentation.slides.insert_clone(0, presentation.slides[0])

        # Uzyskaj dostęp do kontrolki Media Player ActiveX i ustaw ścieżkę wideo
        prop = newPresentation.slides[0].controls[0].properties

        prop.remove("URL")
        prop.add("URL", "Wildlife.mp4")

        # Zapisz prezentację
        newPresentation.save("LinkingVideoActiveXControl_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy Aspose.Slides zachowuje kontrolki ActiveX podczas odczytu i ponownego zapisu, jeśli nie mogą być wykonane w środowisku uruchomieniowym Pythona?**

Tak. Aspose.Slides traktuje je jako część prezentacji i może odczytywać/modyfikować ich właściwości i ramki; wykonywanie samych kontrolek nie jest wymagane do ich zachowania.

**Czym różnią się kontrolki ActiveX od obiektów OLE w prezentacji?**

Kontrolki ActiveX to interaktywne, zarządzane elementy (przyciski, pola tekstowe, odtwarzacz multimediów), natomiast [OLE](/slides/pl/python-net/manage-ole/) odnosi się do osadzonych obiektów aplikacji (np. arkusza Excel). Są one przechowywane i obsługiwane inaczej oraz mają odrębny model właściwości.

**Czy zdarzenia ActiveX i makra VBA działają, jeśli plik został zmodyfikowany przez Aspose.Slides?**

Aspose.Slides zachowuje istniejący znacznik i metadane; jednak zdarzenia i makra działają tylko w programie PowerPoint w systemie Windows, o ile zabezpieczenia na to zezwalają. Biblioteka nie wykonuje VBA.