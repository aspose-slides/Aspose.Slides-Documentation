---
title: Veelgestelde vragen
type: docs
weight: 110
url: /nl/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Deze pagina verzamelt een aantal veelgestelde vragen over:

- [Ondersteunde bestandsformaten](#Supported-File-Formats).
- [Ondersteuning voor Power BI Reporting services](#Support-for-Power-BI-Reporting-services).
- [Installatie](#Installation).
- [Exportconfiguratie](#Export-Configuration).

{{% /alert %}} 
### **Ondersteunde bestandsformaten**
#### **Q: Naar welke formaten kunt u rapporten exporteren met Aspose.Slides for Reporting Services?**
**A**: Met Aspose.Slides for Reporting Services kunt u elk rapport exporteren naar PPT-, PPS-, PPTX-, PPSX-, XPS- of RDL-formaat.
### **Ondersteuning voor Power BI Reporting services**
#### **Q: Ondersteunt Aspose.Slides for Reporting Services Power BI?**
**A**: Ja. Aspose.Slides for Reporting Services ondersteunt het exporteren van gepagineerde rapporten (RDL) in Power BI.
### **Installatie**
#### **Q: Het installatieprogramma start niet. Handmatige installatie leidt niet tot het gewenste resultaat.**
**A**: Zorg ervoor dat .NET Framework 3.5 op uw systeem is geïnstalleerd.
#### **Q: Exportopties ontbreken na installatie van Aspose.Slides for Reporting Services.**
**A**: Als een CodeGroup in rssrvpolicy.config niet correct werkt, kan de parser van het configuratiebestand de laatste secties van de groep overslaan. Verplaats daarom alle CodeGroups die gekoppeld zijn aan Aspose.Slides for Reporting Services naar de bovenkant van het blok dat de Aspose.Slides for Reporting Services CodeGroups bevat.
#### **Q: Kan bestand of assembly Aspose.Slides.ReportingServices niet laden (Uitvoeringsmachtiging kan niet worden verkregen \ Uitzondering van HRESULT: 0x80131418).**
**A**: De foutcode (0x80131418) geeft aan dat de dll‑module niet over voldoende rechten beschikt. Dit kan te wijten zijn aan een beveiligingsfunctie die volledige toegang tot het .dll‑bestand blokkeerde wanneer dit van een andere computer is verkregen. Dit kan worden verholpen door het eigenschappenvenster van het dll‑bestand te openen en op de knop "Unblock" in het tabblad "Security" te klikken.
#### **Q: Kan licentie 'Aspose.Slides.Reporting.Services.lic' niet vinden.**
**A**: Het licentiebestand moet zich bevinden naast de dll of in de map Program Files(x86)\Aspose\Slides\.
### **Exportconfiguratie**
#### **Q: Hoe kan ik de kleur van hyperlinks in een geëxporteerd rapport wijzigen?**
**A**: Elke weergave‑extensie van Aspose.Slides for Reporting Services in rsreportserver.config heeft zijn eigen configuratie. Om de hyperlink‑kleur te wijzigen, stelt u de gewenste waarde in de sectie <HyperlinkColor> in.
#### **Q: In geëxporteerde presentaties wordt tekst in tabellen verticaal uitgerekt.**
**A**: Dit wordt gedaan om het document beter leesbaar te maken. Om de tekst in de tabel weer te geven zoals deze in het rapport verschijnt, stelt u de betreffende Aspose.Slides for Reporting Services‑extensie in op "Normal" in het configuratie‑bestand rsreportserver.config.