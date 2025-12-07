---
title: PPT und PPTX nach JPG konvertieren in C++
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
description: "Konvertieren Sie PowerPoint (PPT, PPTX)-Folien in hochwertige JPG-Bilder in C++ mit Aspose.Slides mithilfe schneller, zuverlässiger Code‑Beispiele."
---

## **Übersicht**

Das Konvertieren von PowerPoint- und OpenDocument-Präsentationen in JPG-Bilder erleichtert das Teilen von Folien, die Leistungsoptimierung und das Einbetten von Inhalten in Websites oder Anwendungen. Aspose.Slides für C++ ermöglicht es Ihnen, PPTX-, PPT- und ODP-Dateien in hochwertige JPEG-Bilder zu verwandeln. Dieser Leitfaden erklärt verschiedene Methoden zur Konvertierung.

Mit diesen Funktionen ist es einfach, Ihren eigenen Präsentationsviewer zu implementieren und für jede Folie ein Thumbnail zu erstellen. Dies kann nützlich sein, wenn Sie Präsentationsfolien vor dem Kopieren schützen oder die Präsentation im Nur-Lese‑Modus demonstrieren möchten. Aspose.Slides ermöglicht das Konvertieren der gesamten Präsentation oder einer einzelnen Folie in Bildformate.

## **Präsentationsfolien in JPG-Bilder konvertieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Holen Sie das Folienobjekt vom Typ [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) aus der Folienammlung der Präsentation.
3. Erstellen Sie ein Bild der Folie mittels der Methode [ISlide.GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/).
4. Rufen Sie die Methode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) auf dem Bildobjekt auf. Übergeben Sie den Ausgabedateinamen und das Bildformat als Argumente.

{{% alert color="primary" %}} 

**Hinweis:** Die Konvertierung von PPT, PPTX oder ODP zu JPG unterscheidet sich in der Aspose.Slides für C++ API von der Konvertierung in andere Formate. Für andere Formate verwenden Sie typischerweise die Methode [IPresentation.Save](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/save/). Für die JPG-Konvertierung müssen Sie jedoch die Methode [IImage.Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) verwenden.

{{% /alert %}} 
```cpp
float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Erstelle ein Folienbild mit dem angegebenen Maßstab.
    auto image = slide->GetImage(scaleX, scaleY);

    // Speichere das Bild im JPEG-Format auf der Festplatte.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Folien in JPG mit benutzerdefinierten Abmessungen konvertieren**

Um die Abmessungen der resultierenden JPG-Bilder zu ändern, können Sie die Bildgröße festlegen, indem Sie sie an die Methode [ISlide.GetImage(Size)](https://reference.aspose.com/slides/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method) übergeben. Dadurch können Sie Bilder mit bestimmten Breiten- und Höhenwerten erzeugen, sodass das Ergebnis Ihren Anforderungen an Auflösung und Seitenverhältnis entspricht. Diese Flexibilität ist besonders nützlich beim Erzeugen von Bildern für Webanwendungen, Berichte oder Dokumentationen, bei denen präzise Bildabmessungen erforderlich sind.

```cpp
Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Erstelle ein Folienbild mit der angegebenen Größe.
    auto image = slide->GetImage(imageSize);

    // Speichere das Bild im JPEG-Format auf der Festplatte.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```


## **Kommentare beim Speichern von Folien als Bilder rendern**

Aspose.Slides für C++ bietet eine Funktion, mit der Kommentare auf den Folien einer Präsentation beim Konvertieren in JPG-Bilder gerendert werden können. Diese Funktion ist besonders nützlich, um Anmerkungen, Feedback oder Diskussionen, die von Mitarbeitenden in PowerPoint-Präsentationen hinzugefügt wurden, zu erhalten. Durch Aktivieren dieser Option sind Kommentare in den erzeugten Bildern sichtbar, wodurch das Prüfen und Teilen von Feedback erleichtert wird, ohne die Originalpräsentationsdatei öffnen zu müssen.

Angenommen, wir haben eine Präsentationsdatei „sample.pptx“ mit einer Folie, die Kommentare enthält:

![Die Folie mit Kommentaren](slide_with_comments.png)

Der folgende C++‑Code konvertiert die Folie in ein JPG‑Bild und bewahrt dabei die Kommentare:
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

    // Die erste Folie in ein Bild konvertieren.
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
- [PowerPoint in SVG konvertieren](/slides/de/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

Um zu sehen, wie Aspose.Slides PowerPoint in JPG‑Bilder konvertiert, probieren Sie diese kostenlosen Online‑Konverter aus: PowerPoint [PPTX zu JPG](https://products.aspose.app/slides/conversion/pptx-to-jpg) und [PPT zu JPG](https://products.aspose.app/slides/conversion/ppt-to-jpg).

{{% /alert %}}

![Kostenloser Online‑PPTX‑zu‑JPG‑Konverter](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und vieles mehr.

Mit denselben in diesem Artikel beschriebenen Prinzipien können Sie Bilder von einem Format in ein anderes konvertieren. Weitere Informationen finden Sie auf diesen Seiten: Konvertieren Sie [Bild zu JPG](https://products.aspose.com/slides/cpp/conversion/image-to-jpg/); konvertieren Sie [JPG zu Bild](https://products.aspose.com/slides/cpp/conversion/jpg-to-image/); konvertieren Sie [JPG zu PNG](https://products.aspose.com/slides/cpp/conversion/jpg-to-png/), konvertieren Sie [PNG zu JPG](https://products.aspose.com/slides/cpp/conversion/png-to-jpg/); konvertieren Sie [PNG zu SVG](https://products.aspose.com/slides/cpp/conversion/png-to-svg/), konvertieren Sie [SVG zu PNG](https://products.aspose.com/slides/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

**Unterstützt diese Methode die Batch‑Konvertierung?**

Ja, Aspose.Slides ermöglicht die Batch‑Konvertierung mehrerer Folien zu JPG in einem einzigen Vorgang.

**Unterstützt die Konvertierung SmartArt, Diagramme und andere komplexe Objekte?**

Ja, Aspose.Slides rendert alle Inhalte, einschließlich SmartArt, Diagramme, Tabellen, Formen und mehr. Die Rendering‑Genauigkeit kann jedoch im Vergleich zu PowerPoint leicht variieren, insbesondere bei benutzerdefinierten oder fehlenden Schriftarten.

**Gibt es Einschränkungen hinsichtlich der Anzahl der verarbeitbaren Folien?**

Aspose.Slides selbst legt keine strikten Obergrenzen für die Anzahl der verarbeitbaren Folien fest. Allerdings können bei großen Präsentationen oder hochauflösenden Bildern Speicher‑Ausnahmefehler auftreten.