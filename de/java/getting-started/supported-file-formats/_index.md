---
title: Unterstützte Dateiformate
type: docs
weight: 106
url: /de/java/supported-file-formats/
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
- Java
- Aspose.Slides
description: "Erfahren Sie, welche Dateiformate Aspose.Slides for Java laden, importieren, speichern und rendern kann und welche API jedes Format liest oder schreibt."
---
## **Übersicht**

Aspose.Slides for Java öffnet und speichert PowerPoint‑ und OpenDocument‑Präsentationen. Es importiert außerdem PDF‑ und HTML‑Inhalte in Folien, speichert Präsentationen in Dokument‑, Web‑ und Bildformate und rendert einzelne Folien und Formen als Bilder. Dieser Artikel listet jedes unterstützte Format auf und nennt die API, die es liest oder schreibt.

Für einen Überblick über die Bearbeitungsfunktionen siehe [Feature‑Übersicht](/slides/de/java/features-overview/).

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
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}
Präsentationen, die mit PowerPoint 95 und früheren Versionen gespeichert wurden, können nicht geöffnet werden. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) erkennt eine PowerPoint‑95‑Datei und meldet `LoadFormat.Ppt95`, jedoch wirft der [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑Konstruktor dafür [PptUnsupportedFormatException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptunsupportedformatexception/).
{{% /alert %}}

## **Unterstützte Dateiformate**

Die Tabelle verwendet vier Vorgänge:

- **Laden**: die [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑Konstruktion öffnet die Datei als editierbare Präsentation.
- **Importieren**: eine [SlideCollection](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/)‑Methode erstellt Folien aus dem Dateiinhalte und fügt sie einer bestehenden Präsentation hinzu. Der Presentation‑Konstruktor konvertiert diese Dateien nicht in Folien.
- **Speichern**: [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) schreibt die Präsentation in eine Datei oder einen Stream. Jedes Format außer XAML wird mit einem [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Wert ausgewählt.
- **Rendern**: eine Rendering‑Methode zeichnet eine Folie oder eine Form als Bild. Formate, die nur gerendert werden, besitzen keinen SaveFormat‑Wert.

|**Format**|**Beschreibung**|**Laden / Importieren**|**Speichern / Rendern**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97‑2003‑Präsentation|Load|Save|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97‑2003‑Vorlage|Load|Save|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97‑2003‑Diashow|Load|Save|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint‑Präsentation|Load|Save|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint‑Vorlage|Load|Save|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint‑Diashow|Load|Save|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint‑Makro‑aktivierte Präsentation|Load|Save|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint‑Makro‑aktivierte Vorlage|Load|Save|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint‑Makro‑aktivierte Diashow|Load|Save|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument‑Präsentation|Load|Save|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|Flat‑XML‑OpenDocument‑Präsentation|Load|Save|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument‑Präsentationsvorlage|Load|Save|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint‑XML‑Präsentation|Load|Save|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|Portable‑Dokumentformat|Import|Save|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|Hypertext‑Markup‑Sprache|Import|Save|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML Paper Specification|—|Save|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|Tagged Image File Format|—|Save, Render|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|Graphics Interchange Format|—|Save, Render|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|Small Web Format (Flash)|—|Save|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|Markdown|—|Save|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|Extensible Application Markup Language|—|Save|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|Portable Network Graphics|—|Render|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG‑Bild|—|Render|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|Bitmap‑Bild|—|Render|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|Enhanced Metafile|—|Render|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|Scalable Vector Graphics|—|Render|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **Laden und Importieren**

- **Laden:** Übergeben Sie einem [Presentation](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#Presentation-java.lang.String-)‑Konstruktor einen Dateipfad oder einen Stream. Das Format wird anhand des Inhalts ermittelt; [LoadOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadoptions/) liefert Einstellungen wie ein Passwort. Um eine Datei vor dem Öffnen zu prüfen, rufen Sie [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) auf, das einen [LoadFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/loadformat/)‑Wert meldet. Für PowerPoint‑XML wird `LoadFormat.Unknown` gemeldet, der Konstruktor öffnet die Datei trotzdem, und [Presentation.getSourceFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getSourceFormat--) liefert dann `SourceFormat.Xml`. Siehe [Open Presentations](/slides/de/java/open-presentation/) und [Determine the Original Presentation Format](/slides/de/java/detect-presentation-source-format/).
- **Importieren:** [SlideCollection.addFromPdf](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/#addFromPdf-java.lang.String-) fügt pro PDF‑Seite eine Folie am Ende einer Präsentation hinzu. [SlideCollection.addFromHtml](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/#addFromHtml-java.lang.String-) erstellt Folien aus HTML, und [SlideCollection.insertFromHtml](https://reference.aspose.com/slides/de/java/com.aspose.slides/slidecollection/#insertFromHtml-int-java.lang.String-) fügt sie an einer angegebenen Position ein. Der Presentation‑Konstruktor importiert nicht: Er wirft bei einer PDF‑Datei [PptUnsupportedFormatException](https://reference.aspose.com/slides/de/java/com.aspose.slides/pptunsupportedformatexception/) und konvertiert HTML‑Markup nicht in Folieninhalt. Siehe [Import Presentations from PDF or HTML](/slides/de/java/import-presentation/).

## **Speichern und Rendern**

- **Speichern:** [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-java.lang.String-int-) schreibt die Präsentation im Format eines [SaveFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/saveformat/)‑Wertes. Überladungen, die zusätzlich ein Options‑Objekt erhalten, steuern die Ausgabe, z. B. [PdfOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/htmloptions/), [Html5Options](https://reference.aspose.com/slides/de/java/com.aspose.slides/html5options/), [TiffOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/tiffoptions/) und [GifOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/gifoptions/). Überladungen, die ein Array von Folienpositionen (beginnend bei 1) erhalten, schreiben nur diese Folien; sie unterstützen PDF, XPS, TIFF, HTML, HTML5, SWF, GIF und Markdown, jedoch nicht die Präsentationsformate oder PowerPoint‑XML. XAML verfügt über eine eigene Überladung, [Presentation.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#save-com.aspose.slides.IXamlOptions-), die [IXamlOptions](https://reference.aspose.com/slides/de/java/com.aspose.slides/ixamloptions/) verwendet. Siehe [Save Presentations](/slides/de/java/save-presentation/), [Convert Presentations](/slides/de/java/convert-presentation/) und [Export Presentations to XAML](/slides/de/java/export-to-xaml/).
- **Rendern:** [Slide.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#getImage-float-float-) und [Shape.getImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#getImage--) geben ein [IImage](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/) zurück, und [IImage.save](https://reference.aspose.com/slides/de/java/com.aspose.slides/iimage/#save-java.lang.String-int-) schreibt es als PNG, JPEG, BMP, GIF oder TIFF, ausgewählt über einen [ImageFormat](https://reference.aspose.com/slides/de/java/com.aspose.slides/imageformat/)‑Wert. [Presentation.getImages](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) rendert alle oder ausgewählte Folien auf einmal. [Slide.writeAsSvg](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#writeAsSvg-java.io.OutputStream-) und [Shape.writeAsSvg](https://reference.aspose.com/slides/de/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-) schreiben SVG, und [Slide.writeAsEmf](https://reference.aspose.com/slides/de/java/com.aspose.slides/slide/#writeAsEmf-java.io.OutputStream-) schreibt EMF. Siehe [Convert Presentation Slides to Images](/slides/de/java/convert-slide/) und [Render Presentation Slides as SVG Images](/slides/de/java/render-a-slide-as-an-svg-image/).

{{% alert color="warning" title="Warning" %}}
ImageFormat enthält zudem die Werte `Emf`, `Wmf`, `Icon`, `Exif` und `MemoryBmp`, aber IImage.save erzeugt diese Formate nicht: Die geschriebene Datei enthält PNG‑Daten. Für ein EMF‑Bild einer Folie verwenden Sie Slide.writeAsEmf.
{{% /alert %}}

## **FAQ**

**Kann ich eine PPT‑Präsentation in PPTX oder ODP konvertieren?**

Ja. Öffnen Sie die PPT‑Datei mit dem Presentation‑Konstruktor und speichern Sie sie mit `SaveFormat.Pptx` bzw. `SaveFormat.Odp`. Siehe [Convert PPT to PPTX](/slides/de/java/convert-ppt-to-pptx/).

**Kann ich eine PDF‑ oder HTML‑Datei als Präsentation öffnen?**

Nein. Der Presentation‑Konstruktor wirft für eine PDF‑Datei PptUnsupportedFormatException und konvertiert HTML‑Markup nicht in Folien. Erstellen oder öffnen Sie eine Präsentation, importieren Sie die PDF‑Seiten bzw. den HTML‑Inhalt mit den oben beschriebenen Methoden der SlideCollection und speichern Sie sie anschließend in einem unterstützten Format.

**Kann ich ein exportiertes PNG‑ oder SVG‑Bild als bearbeitbare Präsentation laden?**

Nein. Die Bildausgabe speichert nur das Aussehen einer Folie, nicht deren Text, Formen oder Diagramme. Bewahren Sie die Originalpräsentation auf, wenn Sie sie später bearbeiten müssen.

**Kann ich PDF/A‑ oder PDF/UA‑Dokumente speichern?**

Ja. Übergeben Sie einem [PdfCompliance](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfcompliance/)‑Wert an [PdfOptions.setCompliance](https://reference.aspose.com/slides/de/java/com.aspose.slides/pdfoptions/#setCompliance-int-): PDF/A‑1a, PDF/A‑1b, PDF/A‑2a, PDF/A‑2b, PDF/A‑2u, PDF/A‑3a, PDF/A‑3b oder PDF/UA.

**Kann ich prüfen, ob eine Datei passwortgeschützt ist, bevor ich sie öffne?**

Ja. [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/de/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) untersucht die Datei, ohne ein Presentation‑Objekt zu erzeugen, und [IPresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/de/java/com.aspose.slides/ipresentationinfo/#isPasswordProtected--) gibt an, ob ein Passwort benötigt wird. Siehe [Password‑Protect Presentations](/slides/de/java/password-protected-presentation/).