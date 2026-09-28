---
title: Installatie van Aspose.Slides voor SharePoint
type: docs
weight: 10
url: /nl/sharepoint/installing-aspose-slides-for-sharepoint/
description: "Installeer Aspose.Slides voor SharePoint op een SharePoint-farm: kies het installatieprogramma voor uw SharePoint-versie, voer de systeemcontrole uit en rolt de oplossing uit en activeer deze."
---
## **Inhoud van het pakket**

Aspose.Slides for SharePoint wordt gedownload vanaf de [downloadpagina](https://releases.aspose.com/slides/nl/sharepoint/) als een ZIP‑archief. Het archief bevat één SharePoint‑oplossingspakket (WSP) en één installatieprogramma voor elke ondersteunde SharePoint‑versie:

| SharePoint‑versie | Installatieprogramma | Oplossingspakket |
| :- | :- | :- |
| SharePoint 2007 | Setup2007.exe | Aspose.Slides.SharePoint2007.wsp |
| SharePoint 2010 | Setup2010.exe | Aspose.Slides.SharePoint2010.wsp |
| SharePoint Server 2013 | Setup2013.exe | Aspose.Slides.SharePoint2013.wsp |
| SharePoint Server 2016 | Setup2016.exe | Aspose.Slides.SharePoint2016.wsp |
| SharePoint Server 2019 | Setup2019.exe | Aspose.Slides.SharePoint2019.wsp |

Elk installatieprogramma heeft een configuratiebestand ernaast (bijvoorbeeld *Setup2019.exe.config*) dat de naam van het te installeren oplossingspakket bevat. De map *License* bevat een koppeling naar de eindgebruikerslicentieovereenkomst en de licentiebewijzen van derden.

Aspose.Slides for SharePoint wordt verpakt als een SharePoint‑oplossing, die door SharePoint over de serverfarm wordt ingezet. De bijbehorende feature wordt vervolgens per site‑collectie geactiveerd of gedeactiveerd.

## **Installatieproces**

Voor de installatie voert het installatieprogramma een systeemcontrole uit. Het controleert of:

- SharePoint is geïnstalleerd op de server.
- De huidige gebruiker de rechten heeft om SharePoint‑oplossingen te installeren en uit te rollen.
- De SharePoint‑administratieservice is gestart.
- De SharePoint‑timer‑service is gestart.
- Het oplossingspakket dat in het configuratiebestand wordt genoemd, aanwezig is.

De administratieservice en de timer‑service zijn nodig omdat sommige installatie‑acties als timer‑jobs worden uitgevoerd die de oplossing naar alle servers in de farm verspreiden.

### **Installatie uitvoeren**

Om Aspose.Slides for SharePoint te installeren:

1. Pak het ZIP‑archief uit naar een lokale schijf op een server in de SharePoint‑farm.
2. Voer het installatieprogramma uit dat overeenkomt met uw SharePoint‑versie (zie de tabel hierboven) en volg de instructies op het scherm. Het installatieprogramma:
   1. Voert de systeemcontrole uit. Het installatieprogramma gaat niet verder als een controle mislukt.

      **Systeemcontrole uitvoeren**

      ![Het systeemcontrolescherm van het installatieprogramma](installing-aspose-slides-for-sharepoint_1.png)

   2. Toont de eindgebruikerslicentieovereenkomst. U moet deze accepteren om verder te gaan.

      **De licentieovereenkomst**

      ![Het licentieovereenkomsscherm van het installatieprogramma](installing-aspose-slides-for-sharepoint_2.png)

   3. Toont de implementatiedoelen. Selecteer de web‑applicaties en site‑collecties waarvoor de feature moet worden geactiveerd.

      **Selectie van implementatiedoelen**

      ![Het scherm ‘Site‑collectie‑implementatiedoelen’ van het installatieprogramma](installing-aspose-slides-for-sharepoint_3.png)

   4. Rol de oplossing uit naar de farm.

      **Installatievoortgang**

      ![Het voortgangsscherm van de installatie van het installatieprogramma](installing-aspose-slides-for-sharepoint_4.png)

   5. Activeert Aspose.Slides for SharePoint op de geselecteerde site‑collecties.
   6. Toont de web‑applicaties en site‑collecties waar de oplossing is uitgerold en geactiveerd.

      **Succesvolle installatie**

      ![Het scherm ‘Installatie voltooid’ van het installatieprogramma](installing-aspose-slides-for-sharepoint_5.png)

{{% alert color="info" title="Note" %}}
De schermafbeeldingen zijn gemaakt op SharePoint 2007. De installatieprogramma’s voor latere versies doorlopen dezelfde schermen.
{{% /alert %}}

Als dezelfde versie van Aspose.Slides for SharePoint al geïnstalleerd is, biedt het installatieprogramma aan deze te repareren of te verwijderen. Als een andere versie geïnstalleerd is, biedt het aan te upgraden of te verwijderen.

Na de installatie verschijnt er een **Convert via Aspose.Slides**‑item in het menu van bestanden in documentbibliotheken van de geselecteerde site‑collecties (op SharePoint 2007 **Convert with Aspose.Slides**). Om een eerste presentatie te converteren, bekijk [Microsoft PowerPoint-documenten converteren naar andere formaten](/slides/nl/sharepoint/converting-microsoft-powerpoint-documents-into-other-formats/). Wat de oplossing toevoegt aan de farm wordt beschreven in [Implementatie en activering](/slides/nl/sharepoint/deployment-and-activation/).

## **FAQ**

**Welk installatieprogramma moet ik uitvoeren?**

Het programma waarvan de naam overeenkomt met uw SharePoint‑versie. Bijvoorbeeld, voer *Setup2016.exe* uit op een SharePoint Server 2016‑farm. Elk installatieprogramma installeert alleen zijn eigen oplossingspakket.

**Heb ik een aparte download nodig voor de gelicentieerde versie?**

Nee. Hetzelfde pakket werkt in evaluatiemodus totdat u de licentie‑oplossing installeert; zie [Aspose.Slides for SharePoint‑licentie installeren](/slides/nl/sharepoint/installing-aspose-slides-for-sharepoint-license/).

**Hoe verwijder ik het product?**

Voer opnieuw hetzelfde installatieprogramma uit en kies **Verwijderen**; zie [Aspose.Slides for SharePoint verwijderen](/slides/nl/sharepoint/uninstalling-aspose-slides-for-sharepoint/).