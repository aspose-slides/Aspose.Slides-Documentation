---
title: PPT und PPTX in C++ zu JPG konvertieren
linktitle: PowerPoint zu JPG
type: docs
weight: 60
url: /de/cpp/convert-powerpoint-to-jpg/
keywords: 
- PowerPoint konvertieren
- Präsentation konvertieren
- Folie konvertieren
- PPT konvertieren
- PPTX konvertieren
- PowerPoint zu JPG
- Präsentation zu JPG
- Folie zu JPG
- PPT zu JPG
- PPTX zu JPG
- PowerPoint als JPG speichern
- Präsentation als JPG speichern
- Folie als JPG speichern
- PPT als JPG speichern
- PPTX als JPG speichern
- PPT nach JPG exportieren
- PPTX nach JPG exportieren
- C++
- Aspose.Slides
description: "Konvertieren Sie PowerPoint (PPT, PPTX)-Folien in hochwertige JPG-Bilder in C++ mit Aspose.Slides mithilfe schneller und zuverlässiger Codebeispiele."
---

## **Überblick**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG‑Bilder erleichtert das Teilen von Folien, optimiert die Leistung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für C++ ermöglicht das Umwandeln von PPTX‑, PPT‑ und ODP‑Dateien in hochwertige JPEG‑Bilder. Dieses Handbuch erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen lässt sich leicht ein eigener Präsentations‑Viewer implementieren und für jede Folie ein Miniaturbild erzeugen. Das kann nützlich sein, wenn Sie Präsentationsfolien vor Kopieren schützen oder die Präsentation im Nur‑Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht die Konvertierung der gesamten Präsentation oder einer bestimmten Folie in Bildformate.

## **Präsentationsfolien in JPG‑Bilder konvertieren**

Hier sind die Schritte, um eine PPT‑, PPTX‑ oder ODP‑Datei in JPG zu konvertieren:

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Holen Sie das Folienobjekt des Typs [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) aus der Foliensammlung der Präsentation.
3. Erzeugen Sie ein Bild der Folie mit der Methode [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
4. Rufen Sie die Methode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 
**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP nach JPG unterscheidet sich von der Konvertierung in andere Formate in der Aspose.Slides‑API für C++. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). Für die JPG‑Konvertierung müssen Sie jedoch die Methode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) verwenden.
{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Erstelle ein Folienbild mit dem angegebenen Maßstab.
    auto image = slide->GetImage(scaleX, scaleY);

    // Speichere das Bild im JPEG-Format auf die Festplatte.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der resultierenden JPG‑Bilder zu ändern, können Sie die Bildgröße übergeben, indem Sie sie an die Methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) übergeben. Dadurch können Sie Bilder mit bestimmten Breiten‑ und Höhenwerten erzeugen, sodass die Ausgabe Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich, wenn Sie Bilder für Webanwendungen, Berichte oder Dokumentationen erzeugen, bei denen präzise Bildabmessungen erforderlich sind.
```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Erstelle ein Folienbild mit der angegebenen Größe.
    auto image = slide->GetImage(imageSize);

    // Speichere das Bild im JPEG-Format auf die Festplatte.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für C++ bietet eine Funktion, mit der Sie Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG‑Bilder rendern können. Diese Funktion ist besonders nützlich, um Anmerkungen, Feedback oder Diskussionen, die von Mitarbeitern in PowerPoint‑Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option stellen Sie sicher, dass Kommentare in den erzeugten Bildern sichtbar sind, was die Überprüfung und Weitergabe von Feedback erleichtert, ohne die Originalpräsentation öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei „sample.pptx“ mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende C++‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt die Kommentare:
```cpp
float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Optionen für die Folienkommentare festlegen.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Konvertiere die erste Folie in ein Bild.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);
        
    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```


Das Ergebnis:

![Das JPG‑Bild mit Kommentaren](image_with_comments.png)

## **Siehe auch**

Weitere Optionen zum Konvertieren von PPT, PPTX oder ODP in Bilder, zum Beispiel:

- [PowerPoint in GIF konvertieren](/slides/de/cpp/convert-powerpoint-to-animated-gif/)
- [PowerPoint in PNG konvertieren](/slides/de/cpp/convert-powerpoint-to-png/)
- [PowerPoint in TIFF konvertieren](/slides/de/cpp/convert-powerpoint-to-tiff/)
- [PowerPoint in SVG rendern](/slides/de/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 
Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX nach JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT nach JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg). 
{{% /alert %}}

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tipp" color="primary" %}}

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr.

Mit den in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Bild zu [JPG konvertieren](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); [JPG zu Bild konvertieren](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); [JPG zu PNG konvertieren](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/); [PNG zu JPG konvertieren](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); [PNG zu SVG konvertieren](https://products.aspose.com/slides/cpp/conversion/png-to-svg/); [SVG zu PNG konvertieren](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch leicht von PowerPoint abweichen, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Beschränkungen für die Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strikten Grenzen für die Anzahl der Folien fest, die Sie verarbeiten können. Bei sehr großen Präsentationen oder hochauflösenden Bildern können jedoch Speicher‑Fehler auftreten.