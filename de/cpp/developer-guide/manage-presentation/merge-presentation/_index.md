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
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für C++, das Ihren Arbeitsablauf optimiert."
---
## **Übersicht**

Aspose.Slides ermöglicht das Zusammenführen von Präsentationen, indem Folien von einer Präsentation in eine andere geklont werden. Dieser Artikel erklärt, wie man gesamte Präsentationen oder ausgewählte Folien zusammenführt, während des Zusammenführens einen Folienmaster oder ein bestimmtes Layout verwendet, Präsentationen mit unterschiedlichen Foliengrößen verarbeitet und zusammengeführte Folien zu einem Präsentationsabschnitt hinzufügt. Außerdem werden praktische Hinweise zum zusammengeführten Inhalt behandelt, einschließlich Sprecher‑Notizen, Kommentare, passwortgeschützte Quelldateien und Thread‑Verwendung.

## **Präsentationszusammenführung**

Wenn Sie eine Präsentation mit einer anderen zusammenführen, kombinieren Sie deren Folien effektiv in einer einzigen Präsentation, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides for C++**](https://products.aspose.com/slides/de/cpp/), ermöglicht es Ihnen jedoch, Präsentationen auf verschiedene Weise zusammenzuführen. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. zusammenführen, ohne sich um Qualitäts‑ oder Datenverlust sorgen zu müssen. 

**Siehe auch**

[Klone Folien](https://docs.aspose.com/slides/de/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie zusammenführen 

* ganze Präsentationen. Alle Folien aus den Präsentationen landen in einer Präsentation
* bestimmte Folien. Ausgewählte Folien landen in einer Präsentation
* Präsentationen im selben Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) miteinander. 

{{% alert title="Note" color="warning" %}} 

Neben Präsentationen ermöglicht Aspose.Slides das Zusammenführen anderer Dateien:

* [Bilder](https://products.aspose.com/slides/de/cpp/merger/image-to-image/), wie zum Beispiel [JPG zu JPG](https://products.aspose.com/slides/de/cpp/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/de/cpp/merger/png-to-png/)
* Dokumente, wie zum Beispiel [PDF zu PDF](https://products.aspose.com/slides/de/cpp/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/de/cpp/merger/html-to-html/)
* Und zwei unterschiedliche Dateien, wie [Bild zu PDF](https://products.aspose.com/slides/de/cpp/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/de/cpp/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/de/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgabepäsentation einen einzigartigen Stil beibehält
* ein bestimmter Stil für alle Folien in der Ausgabepäsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die Methoden [AddClone](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) (aus dem Interface [ISlideCollection](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_slide_collection)) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Präsentationszusammenführungsprozesses definieren. Jedes Presentation‑Objekt verfügt über eine [Slides](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c)‑Sammlung, sodass Sie die `AddClone`‑Methode von der Präsentation aus aufrufen können, in die Sie Folien einfügen möchten. 

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgabepäsentation sind einfach eine Kopie der Folien der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (zum Beispiel Stile, Formatierungsoptionen oder Layouts anwenden), ohne dass die Quellpräsentationen betroffen werden. 

## **Präsentationen zusammenführen** 

Aspose.Slides stellt die Methode [**AddClone (ISlide)**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) bereit, die das Kombinieren von Folien ermöglicht, während die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser C++‑Code zeigt, wie man Präsentationen zusammenführt:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Präsentationen mit einem Folienmaster zusammenführen**

Aspose.Slides stellt die Methode [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) bereit, die das Kombinieren von Folien ermöglicht, während ein Folienmaster‑Präsentations‑Template angewendet wird. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabepäsentation ändern. 

Dieser C++‑Code demonstriert den beschriebenen Vorgang:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 

Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein passendes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf **true** gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/de/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ausgelöst. 

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgabepäsentation ein anderes Folienlayout besitzen, verwenden Sie stattdessen die Methode [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) beim Zusammenführen. 

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um individuelle Folien‑Decks zu erstellen. Aspose.Slides C++ ermöglicht das Auswählen und Importieren ausschließlich der benötigten Folien. Die API bewahrt Formatierung, Layout und Design der Originalfolien. 

Der folgende C++‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/SlideLayoutType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

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
#include <DOM/IPresentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Im obigen Code deklariert.
SmartPtr<ISlide> GetTitleSlide(SmartPtr<IPresentation> presentation);

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

Dieser C++‑Code zeigt, wie man Folien aus Präsentationen kombiniert, während das bevorzugte Folienlayout angewendet wird, um eine einzige Ausgabepäsentation zu erhalten:

```cpp
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert den beschriebenen Vorgang:

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

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

Dieser C++‑Code zeigt, wie man eine bestimmte Folie in einen Abschnitt einer Präsentation einfügt:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (int32_t index = 0; index < pres2->get_Slides()->get_Count(); index++)
{
    auto slide = pres2->get_Slides()->idx_get(index);
    pres1->get_Slides()->AddClone(slide, pres1->get_Sections()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

Die Folie wird am Ende des Abschnitts eingefügt. 

{{% alert title="Tip" color="info" %}}

Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/de/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG zu PNG‑Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und so weiter. 

{{% /alert %}}

## **FAQ**

### Werden Sprecher‑Notizen beim Zusammenführen erhalten?

Ja. Beim Klonen von Folien überträgt Aspose.Slides alle Folienelemente, einschließlich Notizen, Formatierungen und Animationen.

### Werden Kommentare und deren Autoren übertragen?

Kommentare werden als Teil des Folieninhalts mit der Folie kopiert. Die Autorennamen der Kommentare bleiben als Kommentarobjekte in der resultierenden Präsentation erhalten.

### Was ist, wenn die Quellpräsentation passwortgeschützt ist?

Sie muss [mit dem Passwort geöffnet](/slides/de/cpp/password-protected-presentation/) über [LoadOptions::set_Password](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_password/) werden; nach dem Laden können diese Folien sicher in eine nicht geschützte Zieldatei (oder ebenfalls in eine geschützte) geklont werden.

### Wie thread‑sicher ist der Zusammenführungsvorgang?

Verwenden Sie nicht dieselbe [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/)‑Instanz aus mehreren [Threads](/slides/de/cpp/multithreading/). Die empfohlene Regel lautet „ein Dokument – ein Thread“; verschiedene Dateien können parallel in separaten Threads verarbeitet werden.