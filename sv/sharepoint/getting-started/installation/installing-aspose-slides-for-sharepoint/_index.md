---
title: Installera Aspose.Slides för SharePoint
type: docs
weight: 10
url: /sv/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint laddas ner som arkivet Aspose.Slides.SharePoint.zip. Arkivet innehåller: 

- **Aspose.Slides.SharePoint.wsp**: SharePoint‑lösningsfil. Aspose.Slides for SharePoint är paketerad som en SharePoint‑lösning för att underlätta aktivering och inaktivering i serverfarmens alla servrar.
- **Aspose_LicenseAgreement.rtf**: Slutanvändarens licensavtal.
- **Setup.exe**: Installationsprogrammet.
- **Setup.exe.config**: Installationskonfigurationsfilen.

{{% /alert %}} 
## **Installationsprocess**
Innan installationen körs kontrollerar installationsprogrammet att:

- WSS 3.0 eller MOSS 2007 är installerat.
- Användaren har behörighet att installera SharePoint‑lösningar.
- SharePoint‑databasen är online.
- WSS Administration Service är startad.
- WSS Timer Service är startad.

WSS Administration‑ och Timer‑tjänsterna behövs eftersom vissa installationsåtgärder förlitar sig på ett timerjobb för att spridas till alla servrar i serverfarmens.

### **Kör installationen**
För att installera Aspose.Slides for SharePoint: 

1. Packa upp Aspose.Slides.SharePoint zip till den lokala enheten på MOSS 7.0‑ eller WSS 3.0‑servern.
2. Kör setup.exe och följ instruktionerna på skärmen. Installationsprogrammet utför följande åtgärder: 
   1. Kontrollerar installationsförutsättningarna. Installationen fortsätter inte om någon kontroll misslyckas. 

      **Kör en systemkontroll** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Visar slutanvändarens licensavtal. Du måste godkänna avtalet för att fortsätta. 

   **EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Visar val av implementeringsmål. Väljer de webbapplikationer och webbplatssamlingar som funktionen ska aktiveras för. 

   **Välja implementeringsmål** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Distribuerar funktionen till serverfarm. 

   **Installationsförloppsindikatorn** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Aktiverar Aspose.Slides för de valda webbplatssamlingarna och konfigurerar deras överordnade webbapplikationer.
7. Visar en lista över webbapplikationer och webbplatssamlingar som funktionen har distribuerats till och aktiverats för. 

   **Lyckad installation** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)