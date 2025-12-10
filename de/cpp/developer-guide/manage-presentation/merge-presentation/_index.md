---
title: Effizientes Zusammenführen von Präsentationen in C++
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/cpp/merge-presentation/
keywords:
- PowerPoint zusammenführen
- Präsentationen zusammenführen
- Folien zusammenführen
- PPT zusammenführen
- PPTX zusammenführen
- ODP zusammenführen
- PowerPoint kombinieren
- Präsentationen kombinieren
- Folien kombinieren
- PPT kombinieren
- PPTX kombinieren
- ODP kombinieren
- C++
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für C++, um Ihren Arbeitsablauf zu optimieren."
---

{{% alert  title="Tip" color="primary" %}} 

Vielleicht möchten Sie sich die **Aspose kostenlose Online** [Merger-App](https://products.aspose.app/slides/merger) ansehen. Sie ermöglicht es, PowerPoint-Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) zusammenzuführen und Präsentationen in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zu kombinieren.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie deren Folien zu einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, mit denen Benutzer Präsentationen auf diese Weise kombinieren können. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/cpp/) ermöglicht jedoch das Zusammenführen von Präsentationen auf verschiedene Arten. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts- oder Datenverlust sorgen zu müssen. 

**Siehe auch**

[Clone Slides](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen 

* gesamte Präsentationen. Alle Folien aus den Präsentationen landen in einer Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer Präsentation
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in verschiedenen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Note" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/cpp/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* [Dokumente](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/), wie [PDF zu PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Und zwei unterschiedliche Dateien wie [Bild zu PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/), [JPG zu PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen eindeutigen Stil behält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Zum Zusammenführen von Präsentationen stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)‑Methoden (aus dem [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection)‑Interface) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Präsentationszusammenführungsprozesses festlegen. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑Sammlung, sodass Sie die `AddClone`‑Methode der Präsentation aufrufen können, in die Sie Folien einfügen möchten. 

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie die resultierenden Folien ändern (z. B. Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen beeinflusst werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee)‑Methode bereit, mit der Sie Folien kombinieren können, wobei die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser C++‑Code zeigt, wie Sie Präsentationen zusammenführen:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Präsentationen mit einer Folienmaster zusammenführen** 

Aspose.Slides stellt die [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640)‑Methode bereit, mit der Sie Folien kombinieren können, während ein Folienmaster‑Präsentations‑Template angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil für die Folien in der Ausgabepäsentation ändern. 

Dieser C++‑Code demonstriert den beschriebenen Vorgang:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


{{% alert title="Note" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf true gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ausgelöst. 

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1)‑Methode beim Zusammenführen. 

## **Spezifische Folien aus Präsentationen zusammenführen** 

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensätze zu erstellen. Aspose.Slides C++ ermöglicht das Auswählen und Importieren nur der benötigten Folien. Die API bewahrt Formatierung, Layout und Design der Originalfolien. 

Der folgende C++‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:
```cpp
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation)
{
    for (auto&& slide : presentation->get_Slides())
    {
        if (slide->get_LayoutSlide()->get_LayoutType() == SlideLayoutType::Title)
        {
            return slide;
        }
    }
    return nullptr;
}
```

```cpp
auto presentation = MakeObject<Presentation>();
auto presentation1 = MakeObject<Presentation>(u"presentation1.pptx");
auto presentation2 = MakeObject<Presentation>(u"presentation2.pptx");

presentation->get_Slides()->RemoveAt(0);

auto slide1 = GetTitleSlide(presentation1);

if (slide1 != nullptr)
    presentation->get_Slides()->AddClone(slide1);

auto slide2 = GetTitleSlide(presentation2);

if (slide2 != nullptr)
    presentation->get_Slides()->AddClone(slide2);

presentation->Save(u"combined.pptx", SaveFormat::Pptx);

presentation2->Dispose();
presentation1->Dispose();
presentation->Dispose();
```


## **Präsentationen mit einem Folienlayout zusammenführen** 

Dieser C++‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren, während Sie Ihr bevorzugtes Folienlayout darauf anwenden, um eine Ausgabepäsentation zu erhalten:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen** 

{{% alert title="Note" color="warning" %}} 

Sie können Präsentationen mit unterschiedlichen Foliengrößen nicht zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert den beschriebenen Vorgang:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres1Size = pres1->get_SlideSize()->get_Size();

auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
pres2->get_SlideSize()->SetSize(pres1Size.get_Width(), pres1Size.get_Height(), SlideSizeScaleType::EnsureFit);

for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


## **Folien in einen Präsentationsabschnitt einfügen** 

Dieser C++‑Code zeigt, wie Sie eine bestimmte Folie in einen Abschnitt einer Präsentation einfügen:
```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```


Die Folie wird am Ende des Abschnitts hinzugefügt. 

{{% alert title="Tip" color="primary" %}}

Aspose bietet eine [FREE Collage web app](https://products.aspose.app/slides/collage). Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG‑zu‑PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen und mehr. 

{{% /alert %}}

## **FAQ**

**Werden Notizen beim Zusammenführen erhalten?**

Ja. Beim Klonen von Folien übernimmt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

**Werden Kommentare und deren Autoren übertragen?**

Kommentare, als Teil des Folieninhalts, werden mit der Folie kopiert. Die Autorbezeichnungen der Kommentare bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

**Was ist, wenn die Quellpräsentation passwortgeschützt ist?**

Sie muss [mit dem Passwort geöffnet werden](/slides/de/cpp/password-protected-presentation/) über [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/); nach dem Laden können diese Folien sicher in eine ungeschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

**Wie thread‑sicher ist der Zusammenführungs‑Vorgang?**

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)‑Instanz aus [mehreren Threads](/slides/de/cpp/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.