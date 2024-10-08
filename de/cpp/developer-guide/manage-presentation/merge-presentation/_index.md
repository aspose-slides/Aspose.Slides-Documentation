---
title: Präsentation zusammenführen - C++ PowerPoint API
linktitle: Präsentation zusammenführen
type: docs
weight: 40
url: /de/cpp/merge-presentation/
keywords: "PowerPoint zusammenführen, PPTX, PPT, PowerPoint kombinieren, Präsentation zusammenführen, Präsentation kombinieren, C++"
description: Der Artikel erklärt, wie Sie PowerPoint-Präsentationen mit der C++ PowerPoint API oder Bibliothek zusammenführen oder kombinieren können.
---

{{% alert  title="Tipp" color="primary" %}} 

Sie möchten möglicherweise die **kostenlose Online-App** [Merger](https://products.aspose.app/slides/merger) von Aspose ausprobieren. Sie ermöglicht es Benutzern, PowerPoint-Präsentationen im gleichen Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zusammenzuführen.

[![todo:image_alt_text](slides-merger.png)](https://products.aspose.app/slides/merger)

{{% /alert %}} 


## **Präsentationen zusammenführen**

Wenn Sie eine Präsentation mit einer anderen kombinieren, fügen Sie effektiv deren Folien in einer einzigen Präsentation zusammen, um eine Datei zu erhalten. 

{{% alert title="Info" color="info" %}}

Die meisten Präsentationsprogramme (PowerPoint oder OpenOffice) verfügen nicht über Funktionen, die es Benutzern ermöglichen, Präsentationen auf diese Weise zu kombinieren. 

[**Aspose.Slides für C++**](https://products.aspose.com/slides/cpp/) ermöglicht es Ihnen jedoch, Präsentationen auf verschiedene Weise zusammenzuführen. Sie können Präsentationen mit all ihren Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen usw. kombinieren, ohne sich um Verlust von Qualität oder Daten sorgen zu müssen. 

**Siehe auch**

[Folien klonen](https://docs.aspose.com/slides/cpp/clone-slides/)*.* 

{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie 

* gesamte Präsentationen. Alle Folien aus den Präsentationen enden in einer Präsentation
* spezifische Folien. Ausgewählte Folien enden in einer Präsentation
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) untereinander zusammenführen. 

{{% alert title="Hinweis" color="warning" %}} 

Neben Präsentationen ermöglicht es Aspose.Slides Ihnen, andere Dateien zusammenzuführen:

* [Bilder](https://products.aspose.com/slides/cpp/merger/image-to-image/), wie [JPG zu JPG](https://products.aspose.com/slides/cpp/merger/jpg-to-jpg/) oder [PNG zu PNG](https://products.aspose.com/slides/cpp/merger/png-to-png/)
* Dokumente, wie [PDF zu PDF](https://products.aspose.com/slides/cpp/merger/pdf-to-pdf/) oder [HTML zu HTML](https://products.aspose.com/slides/cpp/merger/html-to-html/)
* Und zwei verschiedene Dateien wie [Bild zu PDF](https://products.aspose.com/slides/cpp/merger/image-to-pdf/) oder [JPG zu PDF](https://products.aspose.com/slides/cpp/merger/jpg-to-pdf/) oder [TIFF zu PDF](https://products.aspose.com/slides/cpp/merger/tiff-to-pdf/).

{{% /alert %}}

### **Zusammenführungsoptionen**

Sie können Optionen anwenden, die bestimmen, ob

* jede Folie in der Ausgangspräsentation einen einzigartigen Stil behält
* ein spezifischer Stil für alle Folien in der Ausgangspräsentation verwendet wird. 

Um Präsentationen zusammenzuführen, stellt Aspose.Slides [AddClone](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) Methoden bereit (aus dem [ISlideCollection](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection) Interface). Es gibt mehrere Implementierungen der `AddClone` Methoden, die die Parameter des Präsentationen-Zusammenführungsprozesses definieren. Jedes Präsentationsobjekt hat eine [Slides](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#a9981b38f5a01d9fa5482f05b0a75974c) Sammlung, sodass Sie eine `AddClone` Methode von der Präsentation aufrufen können, in die Sie Folien zusammenführen möchten. 

Die `AddClone` Methode gibt ein `ISlide` Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in einer Ausgangspräsentation sind einfach eine Kopie der Folien aus der Quelle. Daher können Sie Änderungen an den resultierenden Folien vornehmen (z. B. Stile oder Formatierungsoptionen oder Layouts anwenden), ohne sich zu sorgen, dass die Quellpräsentationen betroffen sind. 

## **Präsentationen zusammenführen** 

Aspose.Slides bietet die [**AddClone (ISlide)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0c84ed19c8b1730eb8010613a1c229ee) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während die Folien ihre Layouts und Stile beibehalten (Standardparameter). 

Dieser C++-Code zeigt Ihnen, wie Sie Präsentationen zusammenführen:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Präsentationen mit Masterfolie zusammenführen**

Aspose.Slides bietet die [**AddClone (ISlide, IMasterSlide, bool)**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a6b040e6b30f52ab4644fafdbc650b640) Methode, die es Ihnen ermöglicht, Folien zu kombinieren, während eine Präsentationsvorlage für Masterfolien angewendet wird. Auf diese Weise können Sie, wenn nötig, den Stil der Folien in der Ausgangspräsentation ändern. 

Dieser C++-Code demonstriert die beschriebene Operation:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_Masters()->idx_get(0), true);
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

{{% alert title="Hinweis" color="warning" %}} 

Das Folienlayout für die Masterfolie wird automatisch bestimmt. Wenn ein geeignetes Layout nicht bestimmt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone` Methode auf true gesetzt ist, wird das Layout für die Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/cpp/namespace/aspose.slides#addf0421015ca476c0664c4f8f451877d) ausgelöst. 

{{% /alert %}}

Wenn Sie möchten, dass die Folien in der Ausgangspräsentation ein anderes Folienlayout haben, verwenden Sie stattdessen die [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_slide_collection#a0ed5909b2d92555159007046760ff2f1) Methode beim Zusammenführen. 

## **Bestimmte Folien aus Präsentationen zusammenführen**

Dieser C++-Code zeigt Ihnen, wie Sie spezifische Folien aus verschiedenen Präsentationen auswählen und kombinieren, um eine Ausgangspräsentation zu erhalten:

```cpp
auto pres1 = System::MakeObject<Presentation>(u"pres1.pptx");
auto pres2 = System::MakeObject<Presentation>(u"pres2.pptx");
for (const auto& slide : pres2->get_Slides())
{
    pres1->get_Slides()->AddClone(slide, pres2->get_LayoutSlides()->idx_get(0));
}

pres1->Save(u"combined.pptx", SaveFormat::Pptx);
```

## **Präsentationen mit Folienlayout zusammenführen**

Dieser C++-Code zeigt Ihnen, wie Sie Folien aus Präsentationen kombinieren, während Sie das gewünschte Folienlayout auf diese anwenden, um eine Ausgangspräsentation zu erhalten:

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

{{% alert title="Hinweis" color="warning" %}} 

Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 

{{% /alert %}}

Um 2 Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so anpassen, dass ihre Größe der anderen Präsentation entspricht. 

Dieser Beispielcode demonstriert die beschriebene Operation:

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

## **Folien in eine Präsentationssektion zusammenführen**

Dieser C++-Code zeigt Ihnen, wie Sie eine bestimmte Folie in eine Sektion in einer Präsentation zusammenführen:

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

Die Folie wird am Ende der Sektion hinzugefügt. 

{{% alert title="Tipp" color="primary" %}}

Aspose bietet eine [Kostenlose Collage-Webanwendung](https://products.aspose.app/slides/collage). Mit diesem Onlinedienst können Sie [JPG zu JPG](https://products.aspose.app/slides/collage/jpg) oder PNG zu PNG-Bildern zusammenführen, [Fotogitter](https://products.aspose.app/slides/collage/photo-grid) erstellen usw. 

{{% /alert %}}