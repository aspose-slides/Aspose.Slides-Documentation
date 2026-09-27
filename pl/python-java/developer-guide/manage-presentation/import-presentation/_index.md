---
title: Importowanie prezentacji z PDF lub HTML w Pythonie za pośrednictwem Java
linktitle: Importowanie prezentacji
type: docs
weight: 60
url: /pl/python-java/import-presentation/
keywords:
- importowanie prezentacji
- importowanie slajdu
- importowanie PDF
- importowanie HTML
- PDF do prezentacji
- PDF do PPT
- PDF do PPTX
- PDF do ODP
- HTML do prezentacji
- HTML do PPT
- HTML do PPTX
- HTML do ODP
- PowerPoint
- OpenDocument
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak importować treści PDF i HTML do prezentacji PowerPoint w Pythonie za pośrednictwem Java przy użyciu Aspose.Slides i zapisywać wyniki jako pliki PPTX."
---
## **Wstęp**

Aspose.Slides for Python via Java może konwertować strony PDF lub treść HTML na slajdy PowerPoint bez Microsoft PowerPoint. Klasa [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) udostępnia [addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromPdf) i [addFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromHtml) do dołączania importowanej treści do prezentacji.

Aby uzyskać większą kontrolę nad umieszczaniem HTML, [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertFromHtml) może wstawiać wygenerowane slajdy na określonym indeksie kolekcji lub zaczyna wypełniać dostępne miejsce na istniejącym slajdzie. Długi HTML jest automatycznie podzielony na dodatkowe slajdy, źródło może być podane jako ciąg znaków lub strumień, a zasoby zewnętrzne mogą być ładowane przez [ExternalResourceResolver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/externalresourceresolver/) z użyciem bazowego URI. Zwrócona tablica [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) identyfikuje dotknięte oraz nowo utworzone slajdy.

## **Import z PDF**

Aby przekonwertować dokument PDF na prezentację PowerPoint, zaimportuj jego zawartość do kolekcji slajdów i zapisz wynik jako plik PPTX.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Utwórz nowy obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Wywołaj [addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromPdf) z ścieżką do pliku PDF.
3. Wywołaj [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx), aby zapisać prezentację jako plik PPTX.

Poniższy przykład w Pythonie importuje dokument PDF i zapisuje wygenerowane slajdy jako prezentację PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    presentation.getSlides().addFromPdf("document.pdf")
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Domyślny pusty slajd pozostaje w prezentacji, ponieważ import dodaje slajdy na końcu. Aby zachować tylko zaimportowane strony, wyczyść kolekcję slajdów metodą [SlideCollection.clear](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#clear) przed importem.

Metoda [addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromPdf) zwraca slajdy, które zostały dodane, co jest przydatne, gdy trzeba przetworzyć wyłącznie zaimportowane slajdy.

{{% alert title="Tip" color="success" %}}
Wypróbuj darmową aplikację internetową [PDF to PowerPoint](https://products.aspose.app/slides/pl/import/pdf-to-powerpoint), aby zobaczyć ten proces konwersji w działaniu.
{{% /alert %}}

## **Import z HTML**

Aspose.Slides może również tworzyć slajdy z dokumentu HTML. Źródło może być podane jako tekst HTML lub strumień. Poniższe kroki wykorzystują strumień pliku:

1. Utwórz nowy obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Otwórz plik HTML do odczytu i przekaż strumień do [addFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromHtml).
3. Wywołaj [save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) z [SaveFormat.Pptx](https://reference.aspose.com/slides/pl/python-java/aspose.slides/saveformat/#Pptx), aby zapisać wynik jako plik PPTX.

Poniższy przykład w Pythonie importuje dokument HTML i zapisuje wygenerowane slajdy jako prezentację PowerPoint:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.io import FileInputStream

presentation = Presentation()
try:
    html_stream = FileInputStream("page.html")
    try:
        presentation.getSlides().addFromHtml(html_stream)
    finally:
        html_stream.close()
    presentation.save("presentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Wstawianie treści HTML**

Użyj [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertFromHtml), gdy slajdy wygenerowane z HTML muszą zostać umieszczone w określonym miejscu zamiast na końcu. Indeks jest zerowy i określa pozycję, od której rozpoczyna się import.

Argument `useSlideWithIndexAsStart` kontroluje, jak importer wykorzystuje tę pozycję:

- Gdy wartość jest `False`, importer tworzy nowe slajdy w podanym indeksie i przesuwa istniejące slajdy, które po nich następują.
- Gdy wartość jest `True`, importer zaczyna umieszczać zawartość w dostępnym miejscu na istniejącym slajdzie o tym indeksie. Jeśli HTML nie mieści się, Aspose.Slides automatycznie paginuje go i wstawia dodatkowe slajdy bezpośrednio po slajdzie początkowym.

[SlideCollection.insertFromHtml](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertFromHtml) zwraca tablicę obiektów [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/). Gdy wstawianie rozpoczyna się na nowych slajdach, każdy zwrócony element jest nowo utworzony. Gdy używany jest istniejący slajd jako punkt startowy, tablica zawiera ten dotknięty slajd oraz wszystkie nowe slajdy przepełniające. Można przeglądać tę tablicę zamiast obliczać zakres dotknięty na podstawie liczby slajdów w prezentacji.

### **Wstawianie HTML jako nowych slajdów**

Poniższy przykład podaje HTML jako ciąg znaków i wstawia wygenerowane slajdy pod indeksem kolekcji `1`. Przekazanie `False` pozostawia istniejące slajdy niezmienione, oprócz ich przesunięcia w celu utworzenia miejsca.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    insert_index = 1
    html = "<html><body><h1>Quarterly update</h1><p>This content is inserted before the slide that was at index 1.</p></body></html>"
    inserted_slides = presentation.getSlides().insertFromHtml(insert_index, html, False)

    for slide in inserted_slides:
        print("Inserted slide index:", presentation.getSlides().indexOf(slide))

    presentation.save("presentation-with-inserted-html.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Rozpoczęcie na istniejącym slajdzie**

Następny przykład podaje HTML za pomocą strumienia. Zachowuje kształt nagłówka na istniejącym szablonie slajdu, rozpoczyna import pod zajętym obszarem i pozwala długiemu tekstowi kontynuować na nowych slajdach.

HTML zawiera również względny adres obrazu. [ExternalResourceResolver](https://reference.aspose.com/slides/pl/python-java/aspose.slides/externalresourceresolver/) pobiera zasób, a bazowy URI informuje importer, jak rozwiązać `images/logo.png`. W tym przykładzie plik jest oczekiwany pod `html-assets/images/logo.png`.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ExternalResourceResolver, Presentation, SaveFormat, ShapeType
from java.io import ByteArrayInputStream

presentation = Presentation()
try:
    template_slide = presentation.getSlides().get_Item(0)
    header = template_slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 680, 60)
    header.getTextFrame().setText("Product roadmap")

    html_parts = ["<html><body><img src='images/logo.png' width='120' height='60'><h2>Roadmap details</h2>"]
    for item_index in range(1, 61):
        html_parts.append(f"<p style='font-size:24pt'>Roadmap item {item_index}: detailed implementation notes.</p>")
    html_parts.append("</body></html>")

    html = "".join(html_parts)
    html_data = html.encode("utf-8")
    resolver = ExternalResourceResolver()
    base_directory = Path("html-assets").resolve()
    base_uri = base_directory.as_uri() + "/"

    html_stream = ByteArrayInputStream(html_data)
    try:
        affected_slides = presentation.getSlides().insertFromHtml(0, html_stream, resolver, base_uri, True)
        for slide in affected_slides:
            print("Affected slide index:", presentation.getSlides().indexOf(slide))
    finally:
        html_stream.close()

    presentation.save("presentation-with-html-overflow.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert title="Warning" color="warning" %}}
Niezrestrykowany resolver zasobów zewnętrznych może odczytywać lokalne lub sieciowe zasoby odwoływane przez HTML. Dla niezweryfikowanego wejścia należy najpierw zweryfikować i oczyścić adresy URL zasobów względem listy dozwolonych schematów, katalogów i hostów przed importem HTML.
{{% /alert %}}

## **FAQ**

**Czy Aspose.Slides może wykrywać tabele przy imporcie pliku PDF?**

Tak. Utwórz obiekt [PdfImportOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfimportoptions/), wywołaj [setDetectTables](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfimportoptions/#setDetectTables) z wartością `True` i przekaż te opcje do [addFromPdf](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addFromPdf). Jakość rozpoznawania tabel zależy od struktury i złożoności źródłowego PDF.

{{% alert title="Note" color="info" %}}
Po zaimportowaniu HTML możesz również wyeksportować slajdy do [images](/slides/pl/python-java/convert-powerpoint-to-png/), [TIFF](/slides/pl/python-java/convert-powerpoint-to-tiff/) lub [SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/).
{{% /alert %}}