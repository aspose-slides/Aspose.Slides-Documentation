---  
title: PPTX in PPT umwandeln in C++  
linktitle: PPTX in PPT umwandeln  
type: docs  
weight: 21  
url: /de/cpp/convert-pptx-to-ppt/  
keywords: "C++ PPTX in PPT umwandeln, PowerPoint-Präsentation umwandeln, PPTX in PPT, Python, Aspose.Slides"  
description: "PowerPoint PPTX in PPT umwandeln in C++"  
---  

## **Übersicht**  

Dieser Artikel erklärt, wie man eine PowerPoint-Präsentation im PPTX-Format in das PPT-Format unter Verwendung von C++ umwandelt. Das folgende Thema wird behandelt.  

- PPTX in PPT umwandeln in C++  

## **C++ PPTX in PPT umwandeln**  

Für C++-Beispielcode, um PPTX in PPT umzuwandeln, siehe den folgenden Abschnitt, d.h. [PPTX in PPT umwandeln](#convert-pptx-to-ppt). Es lädt einfach die PPTX-Datei und speichert sie im PPT-Format. Durch die Angabe verschiedener Speicherformate können Sie die PPTX-Datei auch in viele andere Formate wie PDF, XPS, ODP, HTML usw. speichern, wie in diesen Artikeln diskutiert.  

- [C++ PPTX in PDF umwandeln](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-pdf/)  
- [C++ PPTX in XPS umwandeln](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-xps/)  
- [C++ PPTX in HTML umwandeln](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-html/)  
- [C++ PPTX in ODP umwandeln](https://docs.aspose.com/slides/cpp/save-presentation/)  
- [C++ PPTX in Bild umwandeln](https://docs.aspose.com/slides/cpp/convert-powerpoint-to-png/)  

## **PPTX in PPT umwandeln**  
Um eine PPTX in PPT umzuwandeln, übergeben Sie einfach den Dateinamen und das Speicherformat an die **Save**-Methode der [**Presentation**](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) Klasse. Der folgende C++-Codebeispiel wandelt eine Präsentation von PPTX in PPT mithilfe der Standardoptionen um.  

```cpp  
// Lade das PPTX.  
SharedPtr<Presentation> prs = MakeObject<Presentation>(u"sourceFile.pptx");  

// Speichern im PPT-Format.  
prs->Save(u"convertedFile.ppt", Aspose::Slides::Export::SaveFormat::Ppt);  
```