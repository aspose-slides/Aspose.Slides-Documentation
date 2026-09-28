---
title: Unterstützte Dateiformate
type: docs
weight: 96
url: /de/net/supported-file-formats/
keywords:
- unterstützte Dateiformate
- Präsentation laden
- PDF importieren
- HTML importieren
- Präsentation speichern
- Folien rendern
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, welche Dateiformate Aspose.Slides für .NET laden, importieren, speichern und rendern kann und welche API jedes einzelne liest oder schreibt."
---
## **Übersicht**

Aspose.Slides for .NET öffnet und speichert PowerPoint‑ und OpenDocument‑Präsentationen. Es importiert außerdem PDF‑ und HTML‑Inhalte in Folien, speichert Präsentationen in Dokument‑, Web‑ und Bildformate und rendert einzelne Folien und Formen als Bilder. Dieser Artikel listet jedes unterstützte Format auf und benennt die API, die es liest oder schreibt.

Beide NuGet‑Pakete, Aspose.Slides.NET und Aspose.Slides.NET6.CrossPlatform, unterstützen die gleichen Formate; siehe [Installation](/slides/de/net/installation/) um zwischen ihnen zu wählen. Für einen Überblick über die Bearbeitungsfunktionen siehe [Übersicht der Funktionen](/slides/de/net/features-overview/).

## **Unterstützte Microsoft PowerPoint‑Versionen**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint für Microsoft 365 (ehemals Office 365)

{{% alert color="info" title="Note" %}}

Präsentationen, die mit PowerPoint 95 und früheren Versionen gespeichert wurden, können nicht geöffnet werden. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) erkennt eine PowerPoint‑95‑Datei und meldet `LoadFormat.Ppt95`, aber der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑Konstruktor wirft [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) dafür.

{{% /alert %}}

## **Unterstützte Dateiformate**

Die Tabelle verwendet vier Vorgänge:

- **Laden**: Der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑Konstruktor öffnet die Datei als editierbare Präsentation.
- **Importieren**: Eine [SlideCollection](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/)‑Methode erstellt Folien aus dem Dateiinhalte und fügt sie einer bestehenden Präsentation hinzu. Der Presentation‑Konstruktor lädt diese Dateien nicht als Präsentationen.
- **Speichern**: [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) schreibt die Präsentation in eine Datei oder einen Stream. Jeder Format außer XAML wird über einen [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)‑Wert ausgewählt.
- **Rendern**: Eine Rendering‑Methode zeichnet eine Folie oder eine Form als Bild. Formate, die nur gerendert werden, besitzen keinen SaveFormat‑Wert.

|**Format**|**Beschreibung**|**Laden / Importieren**|**Speichern / Rendern**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint‑97‑2003‑Präsentation|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint‑97‑2003‑Vorlage|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint‑97‑2003‑Diashow|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑Präsentation|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑Vorlage|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑Diashow|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑Makro‑unterstützte Präsentation|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑Makro‑unterstützte Vorlage|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑Makro‑unterstützte Diashow|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑Präsentation|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat‑XML‑OpenDocument‑Präsentation|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑Präsentationsvorlage|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint‑XML‑Präsentation|Load|Save|`SaveFormat.Xml`; geladene Dateien melden `SourceFormat.Xml` (kein `LoadFormat`‑Wert)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable Document Format|Import|Save|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext Markup Language|Import|Save|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff`; `ImageFormat.Tiff` (eine Folie)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animiert, alle Folien); `ImageFormat.Gif` (eine Folie)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.Save(IXamlOptions)`, eine XAML‑Datei pro Folie; kein `SaveFormat`‑Wert|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑Bild|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑Bild|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **Laden und Importieren**

- **Laden:** Übergeben Sie einen Dateipfad oder einen Stream an den [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/)‑Konstruktor. Das Format wird aus dem Inhalt ermittelt; [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) liefert Einstellungen wie ein Passwort. Um eine Datei vor dem Öffnen zu prüfen, rufen Sie [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) auf, das einen [LoadFormat](https://reference.aspose.com/slides/net/aspose.slides/loadformat/)‑Wert meldet. Es meldet `LoadFormat.Unknown` für PowerPoint‑XML, aber der Konstruktor öffnet solche Dateien und [Presentation.SourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/) gibt dann `SourceFormat.Xml` zurück. Siehe [Open Presentations](/slides/de/net/open-presentation/) und [Determine the Original Presentation Format](/slides/de/net/detect-presentation-source-format/).
- **Importieren:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfrompdf/) fügt pro PDF‑Seite eine Folie am Ende einer Präsentation hinzu. [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/addfromhtml/) fügt aus HTML erstellte Folien hinzu, und [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/net/aspose.slides/slidecollection/insertfromhtml/) fügt sie an einer angegebenen Position ein. Der Presentation‑Konstruktor importiert nicht: Er wirft bei einer PDF‑Datei [PptUnsupportedFormatException](https://reference.aspose.com/slides/net/aspose.slides/pptunsupportedformatexception/) und konvertiert HTML‑Markup nicht in Folieninhalt. Siehe [Import Presentations from PDF or HTML](/slides/de/net/import-presentation/).

## **Speichern und Rendern**

- **Speichern:** [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) schreibt die Präsentation im Format eines [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/)‑Werts. Überladungen, die zusätzlich ein Options‑Objekt erhalten, steuern die Ausgabe, z. B. [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/) und [GifOptions](https://reference.aspose.com/slides/net/aspose.slides.export/gifoptions/). Überladungen, die ein Array von Folienpositionen (beginnend bei 1) erhalten, schreiben nur diese Folien; sie unterstützen PDF, XPS, TIFF, HTML, HTML5, SWF, GIF und Markdown, jedoch nicht die Präsentationsformate oder PowerPoint‑XML. XAML hat eine eigene Überladung, die [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/) akzeptiert. Siehe [Save Presentations](/slides/de/net/save-presentation/), [Convert Presentations](/slides/de/net/convert-presentation/) und [Export Presentations to XAML](/slides/de/net/export-to-xaml/).
- **Rendern:** [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/) und [Shape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/shape/getimage/) liefern ein [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/), und [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) schreibt es als PNG, JPEG, BMP, GIF oder TIFF, ausgewählt über einen [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)‑Wert. [Presentation.GetImages](https://reference.aspose.com/slides/net/aspose.slides/presentation/getimages/) rendert alle oder ausgewählte Folien auf einmal. [Slide.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/slide/writeassvg/) und [Shape.WriteAsSvg](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) schreiben SVG, und [Slide.WriteAsEmf](https://reference.aspose.com/slides/net/aspose.slides/slide/writeasemf/) schreibt EMF. Siehe [Convert Presentation Slides to Images](/slides/de/net/convert-slide/) und [Render a Slide as an SVG Image](/slides/de/net/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}

ImageFormat enthält außerdem die Werte `Emf`, `Wmf`, `Icon`, `Exif` und `MemoryBmp`, aber IImage.Save erzeugt diese Formate nicht: Die Datei enthält PNG‑Daten. Für ein EMF‑Bild einer Folie verwenden Sie Slide.WriteAsEmf.

{{% /alert %}}

## **FAQ**

**Kann ich eine PPT‑Präsentation in PPTX oder ODP konvertieren?**

Ja. Öffnen Sie die PPT‑Datei mit dem Presentation‑Konstruktor und speichern Sie sie mit `SaveFormat.Pptx` oder `SaveFormat.Odp`. Siehe [PPT in PPTX konvertieren](/slides/de/net/convert-ppt-to-pptx/).

**Kann ich eine PDF‑ oder HTML‑Datei als Präsentation öffnen?**

Nein. Erstellen oder öffnen Sie eine Präsentation, importieren Sie die PDF‑Seiten bzw. den HTML‑Inhalt mit den oben beschriebenen SlideCollection‑Methoden und speichern Sie sie anschließend in einem unterstützten Format.

**Kann ich ein exportiertes PNG‑ oder SVG‑Bild als editierbare Präsentation laden?**

Nein. Bildausgaben erfassen nur das Aussehen einer Folie, nicht deren Text, Formen oder Diagramme. Bewahren Sie die Ausgangspräsentation, wenn Sie sie später bearbeiten müssen.

**Kann ich PDF/A‑ oder PDF/UA‑Dokumente speichern?**

Ja. Setzen Sie [PdfOptions.Compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) auf einen [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/)‑Wert: PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b oder PDF/UA.

**Kann ich prüfen, ob eine Datei kennwortgeschützt ist, bevor ich sie öffne?**

Ja. [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/getpresentationinfo/) untersucht die Datei, ohne ein Presentation‑Objekt zu erzeugen, und seine [IsPasswordProtected](https://reference.aspose.com/slides/net/aspose.slides/ipresentationinfo/ispasswordprotected/)‑Eigenschaft meldet, ob ein Kennwort erforderlich ist. Siehe [Password‑Protect Presentations](/slides/de/net/password-protected-presentation/).

**Unterstützen die beiden NuGet‑Pakete unterschiedliche Formate?**

Nein. Aspose.Slides.NET und Aspose.Slides.NET6.CrossPlatform haben dieselben LoadFormat‑ und SaveFormat‑Werte sowie dieselben Import‑ und Rendering‑Methoden. Sie unterscheiden sich nur in den Plattformen, auf denen sie laufen, und in den jeweiligen Plattform‑Anforderungen; siehe [Installation](/slides/de/net/installation/).