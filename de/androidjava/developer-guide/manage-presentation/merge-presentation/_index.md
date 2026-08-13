---
title: Präsentationen auf Android effizient zusammenführen
linktitle: Präsentationen zusammenführen
type: docs
weight: 40
url: /de/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Müheloses Zusammenführen von PowerPoint (PPT, PPTX) und OpenDocument (ODP) Präsentationen mit Aspose.Slides für Android via Java, um Ihren Arbeitsablauf zu optimieren."
---
## **Übersicht**

Das Zusammenführen von PowerPoint- und OpenDocument-Präsentationen ist in vielen Android‑Anwendungen eine gängige Aufgabe, insbesondere beim Erstellen von Berichten, beim Zusammenstellen von Folien aus unterschiedlichen Quellen oder bei der Automatisierung von Präsentations‑Workflows. Aspose.Slides bietet eine leistungsstarke und einfach zu nutzende API, um mehrere PPT‑, PPTX‑ oder ODP‑Dateien zu einer einzigen Präsentation zu kombinieren, ohne Microsoft PowerPoint, LibreOffice oder OpenOffice zu installieren.

In diesem Leitfaden lernen Sie, wie Sie PowerPoint‑ und OpenDocument‑Präsentationen mit nur wenigen Codezeilen zusammenführen. Wir stellen gebrauchsfertige Beispiele bereit und zeigen, wie Sie die Folienformatierung, Layouts und andere Präsentationselemente während des Zusammenführens beibehalten.

Egal, ob Sie eine Enterprise‑Anwendung oder ein einfaches Automatisierungstool bauen, Aspose.Slides ermöglicht ein schnelles, zuverlässiges und skalierbares Zusammenführen von Präsentationen. Aspose.Slides erlaubt das Zusammenführen von Präsentationen auf verschiedene Weise. Sie können Präsentationen mit allen Formen, Stilen, Texten, Formatierungen, Kommentaren, Animationen und mehr kombinieren – ohne Qualitäts‑ oder Datenverlust zu befürchten.

{{% alert color="info" %}}
Siehe auch: [Folien klonen](https://docs.aspose.com/slides/de/androidjava/clone-slides/)
{{% /alert %}}

### **Was kann zusammengeführt werden**

Mit Aspose.Slides können Sie

* ganze Präsentationen zusammenführen. Alle Folien aus den Präsentationen landen in einer Datei
* bestimmte Folien zusammenführen. Ausgewählte Folien landen in einer Datei
* Präsentationen in einem Format (PPT zu PPT, PPTX zu PPTX usw.) und in unterschiedlichen Formaten (PPT zu PPTX, PPTX zu ODP usw.) zueinander zusammenführen.

### **Zusammenführungs‑Optionen**

Sie können Optionen festlegen, die bestimmen, ob

* jede Folie in der Ausgabedatei einen eigenen Stil behält
* ein einheitlicher Stil für alle Folien in der Ausgabedatei verwendet wird.

Um Präsentationen zusammenzuführen, stellt Aspose.Slides die [AddClone](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methoden (aus der [ISlideCollection](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection)‑Schnittstelle) bereit. Es gibt mehrere Implementierungen der `AddClone`‑Methoden, die die Parameter des Zusammenführungsprozesses definieren. Jedes Presentation‑Objekt besitzt eine [Slides](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/Presentation#getSlides--)‑Sammlung, sodass Sie eine `AddClone`‑Methode von der Präsentation aus aufrufen können, zu der Sie Folien hinzufügen möchten.

Die `AddClone`‑Methode gibt ein `ISlide`‑Objekt zurück, das ein Klon der Quellfolie ist. Die Folien in der Ausgabedatei sind einfach Kopien der Quellfolien. Daher können Sie die resultierenden Folien (z. B. Stile, Formatierungsoptionen oder Layouts) ändern, ohne die Quellpräsentationen zu beeinflussen.

## **Präsentationen zusammenführen**

Aspose.Slides stellt die [**AddClone(ISlide)**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑Methode bereit, die das Kombinieren von Folien ermöglicht, wobei die Layouts und Stile der Folien erhalten bleiben (Standardparameter).

Dieser Java‑Code zeigt, wie Sie Präsentationen zusammenführen:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Präsentationen mit einer Folienmaster‑Vorlage zusammenführen**

Aspose.Slides stellt die [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑Methode bereit, die das Kombinieren von Folien unter Anwendung einer Folienmaster‑Vorlage ermöglicht. Auf diese Weise können Sie bei Bedarf den Stil der Folien in der Ausgabedatei ändern.

Dieser Java‑Code demonstriert die beschriebene Operation:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Hinweis" color="warning" %}} 
Das Folienlayout für den Folienmaster wird automatisch ermittelt. Wenn kein geeignetes Layout ermittelt werden kann und der boolesche Parameter `allowCloneMissingLayout` der `AddClone`‑Methode auf `true` gesetzt ist, wird das Layout der Quellfolie verwendet. Andernfalls wird eine [PptxEditException](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/PptxEditException) ausgelöst.
{{% /alert %}}

Möchten Sie, dass die Folien in der Ausgabedatei ein anderes Folienlayout erhalten, verwenden Sie stattdessen die [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/de/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑Methode beim Zusammenführen.

## **Bestimmte Folien aus Präsentationen zusammenführen**

Das Zusammenführen bestimmter Folien aus mehreren Präsentationen ist nützlich, um benutzerdefinierte Foliensets zu erstellen. Aspose.Slides für Android via Java ermöglicht es Ihnen, nur die benötigten Folien auszuwählen und zu importieren. Die API bewahrt Formatierung, Layout und Design der Originalfolien.

Der folgende Java‑Code erstellt eine neue Präsentation, fügt Titelfolien aus zwei anderen Präsentationen hinzu und speichert das Ergebnis in einer Datei:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Präsentationen mit einem Folienlayout zusammenführen**

Dieser Java‑Code zeigt, wie Sie Folien aus Präsentationen kombinieren und dabei Ihr bevorzugtes Folienlayout anwenden, um eine einzelne Ausgabedatei zu erhalten:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Präsentationen mit unterschiedlichen Foliengrößen zusammenführen**

{{% alert title="Hinweis" color="warning" %}} 
Sie können keine Präsentationen mit unterschiedlichen Foliengrößen zusammenführen. 
{{% /alert %}}

Um zwei Präsentationen mit unterschiedlichen Foliengrößen zusammenzuführen, müssen Sie eine der Präsentationen so skalieren, dass ihre Größe der der anderen Präsentation entspricht.

Dieser Beispielcode demonstriert die beschriebene Vorgehensweise:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Folien zu einem Präsentationsabschnitt zusammenführen**

Dieser Java‑Code zeigt, wie Sie eine bestimmte Folie zu einem Abschnitt einer Präsentation hinzufügen:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Die Folie wird am Ende des Abschnitts eingefügt.

{{% alert title="Tipp" color="info" %}}
Aspose stellt eine [KOSTENLOSE Collage‑Web‑App](https://products.aspose.app/slides/de/collage) bereit. Mit diesem Online‑Dienst können Sie [JPG zu JPG](https://products.aspose.app/slides/de/collage/jpg) oder PNG zu PNG Bilder zusammenführen, [Fotogitter](https://products.aspose.app/slides/de/collage/photo-grid) erstellen und vieles mehr.
{{% /alert %}}

## **FAQ**

### Gibt es Beschränkungen für die Anzahl der Folien beim Zusammenführen von Präsentationen?

Keine strikten Beschränkungen. Aspose.Slides kann große Dateien verarbeiten, aber die Leistung hängt von Dateigröße und Systemressourcen ab. Für sehr große Präsentationen wird empfohlen, eine 64‑Bit‑JVM zu verwenden und ausreichend Heap‑Speicher zuzuweisen.

### Kann ich Präsentationen mit eingebetteten Video‑ oder Audiodateien zusammenführen?

Ja, Aspose.Slides bewahrt multimediale Inhalte, die in Folien eingebettet sind, jedoch kann die resultierende Präsentation erheblich größer werden.

### Werden Schriften beim Zusammenführen von Präsentationen erhalten?

Ja. Schriften, die in Quellpräsentationen verwendet werden, bleiben im Ausgabedokument erhalten, vorausgesetzt, sie sind im System installiert oder [eingebettet](/slides/de/androidjava/embedded-font/).