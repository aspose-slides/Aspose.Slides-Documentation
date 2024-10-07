---
title: Präsentation speichern - C++ PowerPoint-Bibliothek
linktitle: Präsentation speichern
type: docs
weight: 80
url: /cpp/save-presentation/
description: C++ PowerPoint-API oder Bibliothek ermöglicht es Ihnen, Präsentationen in eine Datei oder einen Stream zu speichern. Sie können eine Präsentation von Grund auf neu erstellen oder eine bestehende modifizieren.
---

{{% alert title="Info" color="info" %}}

Um zu lernen, wie man Präsentationen öffnet oder lädt, siehe den Artikel [*Präsentation öffnen*](https://docs.aspose.com/slides/cpp/open-presentation/).

{{% /alert %}}

Der hier behandelte Artikel erklärt, wie man Präsentationen speichert.

Die [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse hält den Inhalt einer Präsentation. Egal, ob Sie eine Präsentation von Grund auf neu erstellen oder eine bestehende modifizieren, wenn Sie fertig sind, möchten Sie die Präsentation speichern. Mit Aspose.Slides für C++ kann sie als **Datei** oder **Stream** gespeichert werden. Dieser Artikel erklärt, wie man eine Präsentation auf verschiedene Arten speichert:

## **Präsentation in Datei speichern**
Speichern Sie eine Präsentation in Dateien, indem Sie die **Presentation** Klasse [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode aufrufen. Übergeben Sie einfach den Dateinamen und das Speicherformat an die [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index) Methode. Die nachfolgenden Beispiele zeigen, wie man eine Präsentation mit Aspose.Slides für C++ speichert.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveToFile-SaveToFile.cpp" >}}
## **Präsentation in Stream speichern**
Es ist möglich, eine Präsentation in einen Stream zu speichern, indem man einen Ausgabestream an die [Presentation]() Klasse Save-Methode übergibt. Es gibt viele Arten von Streams, in die eine Präsentation gespeichert werden kann. Im folgenden Beispiel haben wir eine neue Präsentationsdatei erstellt, Text in eine Form eingefügt und die Präsentation in den Stream gespeichert.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStream-SaveToStream.cpp" >}}


## **Präsentation mit vordefiniertem Ansichtstyp speichern**
Aspose.Slides für C++ bietet die Möglichkeit, den Ansichtstyp für die generierte Präsentation festzulegen, wenn sie in PowerPoint über die [ViewProperties](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties) Klasse geöffnet wird. Die [LastView](http://www.aspose.com/api/net/slides/aspose.slides/viewproperties/properties/index) Eigenschaft wird verwendet, um den Ansichtstyp mithilfe des [ViewType](http://www.aspose.com/api/net/slides/aspose.slides/viewtype) Enumerators festzulegen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsPredefinedViewType-SaveAsPredefinedViewType.cpp" >}}

## **Präsentation im strikten Office Open XML-Format speichern**
Aspose.Slides ermöglicht es Ihnen, die Präsentation im strikten Office Open XML-Format zu speichern. Zu diesem Zweck bietet es die **PptxOptions** Klasse, in der Sie die Conformance Eigenschaft beim Speichern der Präsentationsdatei festlegen können. Wenn Sie den Wert auf **Conformance.Iso29500_2008_Strict** setzen, wird die Ausgabedatei der Präsentation im strikten Office Open XML-Format gespeichert.

Der folgende Beispielcode erstellt eine Präsentation und speichert sie im strikten Office Open XML-Format. Während des Aufrufs der Save-Methode für die Präsentation wird das **PptxOptions** Objekt mit der Conformance-Eigenschaft auf **Conformance.Iso29500_2008_Strict** übergeben.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-SaveToStrictOpenXML-SaveToStrictOpenXML.cpp" >}}


## **Speichern von Fortschrittsaktualisierungen in Prozent**
Ein neues **IProgressCallback**-Interface wurde dem **ISaveOptions**-Interface und der **SaveOptions**-abstrakten Klasse hinzugefügt. Das **IProgressCallback**-Interface stellt ein Callback-Objekt für das Speichern von Fortschrittsaktualisierungen in Prozent dar.

Die folgenden Codebeispiele zeigen, wie man das IProgressCallback-Interface verwendet:

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-CovertToPDFWithProgressUpdate.cpp" >}}

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-CovertToPDFWithProgressUpdate-ExportProgressHandler.cpp" >}}

{{% alert title="Info" color="info" %}}

Mit seiner eigenen API hat Aspose eine [kostenlose PowerPoint-Splitter-App](https://products.aspose.app/slides/splitter) entwickelt, die es den Benutzern ermöglicht, ihre Präsentationen in mehrere Dateien aufzuteilen. Im Wesentlichen speichert die App ausgewählte Folien aus einer bestimmten Präsentation als neue PowerPoint (PPTX oder PPT) Dateien.

{{% /alert %}}