---
title: "How to Extract Text from PPT, PPTX, and ODP Files Using Open XML SDK in .NET"
linktitle: Open XML SDK
type: docs
weight: 20
url: /net/extracting-text-on-cloud-platforms-using-open-xml-sdk/
keywords:
- cloud platforms
- cloud integration
- Open XML SDK
- PPTX text extraction
- .NET slide processing
- presentation text extraction
- master slide
- speaker notes
- extracting text from slides
- C#
description: "Learn how to extract text from PPT, PPTX and ODP in .NET using Open XML SDK, with XML-based access, performance tips, and conversion workarounds for cloud apps."
---

# Extracting Text from PPT, PPTX, ODP Using Open XML SDK

## Open XML SDK

The **Open XML SDK** provides a highly structured and efficient method for extracting text from presentation files—especially **PPTX**, which adheres to the Open XML standard. By offering direct access to the underlying XML, this SDK enables faster and more flexible handling of slide content compared to traditional methods.

## Direct XML Access

- **Analyze Text Directly**: The Open XML SDK lets you extract text from XML parts without rendering slides.
- **Structured Elements**: Because text is stored in well-defined XML tags, it’s simpler to retrieve and process.

### Example: Extracting Text Directly from Slide XML Content

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    var slidePart = presentation.PresentationPart.SlideParts.FirstOrDefault();
    if (slidePart != null)
    {
        var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
        foreach (var text in textElements)
        {
            Console.WriteLine(text.Text);
        }
    }
}
```

## Performance Advantages

- **Faster Extraction**: Bypasses the overhead of opening PowerPoint or other high-level APIs.
- **Lower Memory Usage**: Only relevant XML parts are accessed, reducing resource consumption.
- **No Microsoft PowerPoint Needed**: Frees you from extra installation requirements.

### Example: Efficiently Extracting Text Without Loading the Entire Presentation

```csharp
using (PresentationDocument presentation = PresentationDocument.Open("presentation.pptx", false))
{
    foreach (var slidePart in presentation.PresentationPart.SlideParts)
    {
        var texts = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>().Select(t => t.Text);
        Console.WriteLine(string.Join(" ", texts));
    }
}
```

## Identifying Text Elements

### Specifics of Extracting Text from Presentations

When extracting text from presentations, consider these factors:

- **Text May Reside in Different Sections**: Regular slides, master slides, layouts, or speaker notes.
- **Default Placeholders**: Master slides and layouts can include placeholders (e.g., “Click to edit Master title style”) that aren’t actual presentation content.
- **Filtering Empty or Hidden Text**: Some elements might be empty or not intended for display.

### Tags Containing Text

In a **PPTX** file, text is generally stored in:
- `<a:t>` elements inside `<a:p>` (paragraphs)
- `<a:r>` elements (text segments within paragraphs)

### Example: Extracting All Text Elements from a Slide

```csharp
var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>();
foreach (var text in textElements)
{
    Console.WriteLine(text.Text);
}
```

## ODP and PPT

### Inability to Extract Text Directly

- Unlike **PPTX**, **PPT** (binary format) and **ODP** (OpenDocument Presentation) **are not supported** by Open XML SDK.
- **PPT** stores content in a closed binary format, complicating text extraction.
- **ODP** relies on **OpenDocument XML**, which differs structurally from PPTX.

### Workaround: Converting to PPTX

To extract text from **PPT** or **ODP**, the recommended approach is:

1. **Convert PPT → PPTX** using PowerPoint or a third-party tool.  
2. **Convert ODP → PPTX** via LibreOffice or PowerPoint.  
3. **Extract text** from the new PPTX using Open XML SDK.

### Example: Converting ODP to PPTX via LibreOffice Command Line

```sh
soffice --headless --convert-to pptx presentation.odp
```

## Supported Platforms and Frameworks

- **Windows**: .NET Framework 4.6.1 and above, .NET Core 2.1+, .NET 5/6/7.
- **Linux/macOS**: .NET Core 2.1+, .NET 5/6/7.
- **Cloud Environments**: Microsoft Azure Functions, AWS Lambda (.NET Core), Docker containers.
- **Compatibility with Office Applications**: No Microsoft Office installation required.
- **Supported Programming Languages**: Open XML SDK can be used with **C#**, **VB.NET**, **F#**, and other .NET-supported languages.

## Conclusion

Leveraging the **Open XML SDK** for **PPTX text extraction** offers both efficiency and clarity, whereas **PPT and ODP** demand an initial conversion step for smooth processing. Adopting this approach ensures **high performance**, **flexibility**, and **broad compatibility** with modern .NET applications.