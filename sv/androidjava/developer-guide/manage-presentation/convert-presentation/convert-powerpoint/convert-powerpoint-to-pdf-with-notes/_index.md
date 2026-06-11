---
title: Konvertera PowerPoint-presentationer till PDF med noteringar på Android
linktitle: PowerPoint till PDF med noteringar
type: docs
weight: 50
url: /sv/androidjava/convert-powerpoint-to-pdf-with-notes/
keywords:
- konvertera PowerPoint
- konvertera presentation
- konvertera bild
- konvertera PPT
- konvertera PPTX
- PowerPoint till PDF
- presentation till PDF
- bild till PDF
- PPT till PDF
- PPTX till PDF
- spara presentation som PDF
- spara PPT som PDF
- spara PPTX som PDF
- exportera PPT till PDF
- exportera PPTX till PDF
- talarnoteringar
- PDF med noteringar
- Android
- Java
- Aspose.Slides
description: "Konvertera formaten PPT och PPTX till PDF med noteringar med hjälp av Aspose.Slides för Android via Java. Bevara layouter och talarnoteringar för professionella presentationer."
---
## **Översikt**

I den här artikeln kommer du att lära dig hur du konverterar PowerPoint‑presentationer till PDF‑format med talarnoteringar med hjälp av Aspose.Slides. Denna guide täcker de nödvändiga stegen och ger kodexempel för att du ska kunna utföra uppgiften effektivt. I slutet av artikeln kommer du att kunna:

- Implementera konverteringsprocessen för att omvandla PowerPoint‑bilder till PDF‑dokument samtidigt som talarnoteringarna bevaras.
- Anpassa den genererade PDF‑filen så att talarnoteringarna inkluderas och formateras enligt dina krav.

## **Konvertera PowerPoint till PDF med anteckningar**

Metoden `save` i klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/) kan användas för att konvertera en PPT‑ eller PPTX‑presentation till en PDF med talarnoteringar. Med Aspose.Slides laddar du bara presentationen, konfigurerar layoutalternativen med klassen [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/notescommentslayoutingoptions/) för att inkludera talarnoteringar och sparar sedan filen som en PDF. Följande kodexempel visar hur du konverterar en exempelpresentation till en PDF i vy med notesslides.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
	// Konfigurera PDF-alternativ för att rendera talarnoteringar.
	NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
	notesOptions.setNotesPosition(NotesPositions.BottomFull); // Rendera talarnoteringar under bilden.

	PdfOptions pdfOptions = new PdfOptions();
	pdfOptions.setSlidesLayoutOptions(notesOptions);

	// Spara presentationen som PDF med talarnoteringar.
	presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
	if (presentation != null) presentation.dispose();
}
```

{{% alert color="primary" %}} 
Du kanske vill kolla in Aspose [Online PowerPoint till PDF‑konverterare](https://products.aspose.app/slides/sv/conversion). 
{{% /alert %}}