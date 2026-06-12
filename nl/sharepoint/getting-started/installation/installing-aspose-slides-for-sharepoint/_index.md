---
title: Installatie van Aspose.Slides voor SharePoint
type: docs
weight: 10
url: /nl/sharepoint/installing-aspose-slides-for-sharepoint/
---
{{% alert color="primary" %}} 

Aspose.Slides for SharePoint wordt gedownload als het archief Aspose.Slides.SharePoint.zip. Het archief bevat: 

- **Aspose.Slides.SharePoint.wsp**: SharePoint‑oplossingsbestand. Aspose.Slides for SharePoint wordt verpakt als een SharePoint‑oplossing om activering en deactivering in de serverfarm te vergemakkelijken.
- **Aspose_LicenseAgreement.rtf**: De eindgebruikerslicentieovereenkomst.
- **Setup.exe**: Het installatieprogramma.
- **Setup.exe.config**: Het configuratiebestand van de installatie.

{{% /alert %}} 
## **Installatieproces**
Voordat de installatie wordt uitgevoerd, controleert het installatieprogramma dat:

- WSS 3.0 of MOSS 2007 is geïnstalleerd.
- De gebruiker rechten heeft om SharePoint‑oplossingen te installeren.
- De SharePoint‑database online is.
- De WSS‑administratieservice is gestart.
- De WSS‑timerservice is gestart.

De WSS‑administratie‑ en timerservices zijn nodig omdat sommige installatie‑acties afhankelijk zijn van een timer‑taak die zich naar alle servers in de serverfarm verspreidt. 
### **De installatie uitvoeren**
Om Aspose.Slides for SharePoint te installeren: 

1. Pak het Aspose.Slides.SharePoint‑zip‑archief uit naar de lokale schijf op de MOSS 7.0‑ of WSS 3.0‑server.
2. Voer setup.exe uit en volg de instructies op het scherm.
   Het installatieprogramma voert de volgende acties uit: 
   1. Controleert de installatie‑vereisten. De installatie zal niet doorgaan als een controle mislukt. 

      **Systeemcontrole uitvoeren** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)




3. Toont de eindgebruikerslicentieovereenkomst. U moet de overeenkomst accepteren om verder te gaan. 

   **De EULA** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)




4. Toont de selectie van implementatiedoelen. Selecteert de webapplicaties en site‑collecties waarvoor de functie geactiveerd moet worden. 

   **Selecteren van implementatiedoelen** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)




5. Implementeert de functie in de serverfarm. 

   **De voortgangsbalk van de installatie** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)




6. Activeert Aspose.Slides voor de geselecteerde site‑collecties en configureert hun bovenliggende webapplicaties.
7. Toont een lijst van webapplicaties en site‑collecties waarvoor de functie is geïmplementeerd en geactiveerd. 

   **Succesvolle installatie** 

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)