---
title: Installeren van de Aspose.Slides voor SharePoint-licentie
type: docs
weight: 10
url: /nl/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Installeer de Aspose.Slides voor SharePoint-licentie op een SharePoint-farm: voeg de licentie-oplossing toe aan de oplossingsopslag, implementeer deze, en controleer of geconverteerde bestanden geen evaluatiewatermerk meer bevatten."
---
{{% alert color="info" title="Note" %}}

Zodra u tevreden bent met uw evaluatie, kunt u een licentie [aanschaffen](https://purchase.aspose.com/pricing/slides/sharepoint/). Voordat u koopt, zorg ervoor dat u de voorwaarden van het licentie‑abonnement begrijpt en ermee akkoord gaat. De licentie wordt per e‑mail naar u verzonden zodra de bestelling is betaald.

De licentie is een ZIP‑archief dat een reguliere SharePoint‑oplossingspakket bevat. Het archief bevat:

- Aspose.Slides.SharePoint.License.wsp – het SharePoint‑oplossingspakketbestand. De licentie wordt verpakt als een SharePoint‑oplossing om de uitrol en het intrekken binnen een serverfarm eenvoudig te maken.
- readme.txt – Installatie‑instructies voor de licentie.

{{% /alert %}}

## **De licentie implementeren**

De licentie‑installatie wordt uitgevoerd vanaf de serverconsole via **stsadm.exe**.

{{% alert color="info" title="Note" %}}

De paden zijn in de volgende sectie weggelaten voor de duidelijkheid.

{{% /alert %}}

Voer de volgende stappen uit om de Aspose.Slides for SharePoint‑licentie te implementeren:

1. Voer stsadm uit om de oplossing toe te voegen aan de SharePoint‑oplossingsopslag:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Implementeer de oplossing op alle servers in de farm:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Voer administratieve timer‑taken uit om de implementatie onmiddellijk te voltooien:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

De `addsolution`‑operatie neemt het pad van het oplossingsbestand in `-filename`; de `deploysolution`‑operatie neemt de naam van de oplossing die al in de oplossingsopslag staat in `-name`.

{{% alert color="info" title="Note" %}}

U krijgt een waarschuwing bij het uitvoeren van de implementatiestap als de SharePoint‑Administratieservice niet draait. **stsadm.exe** is afhankelijk van deze service en de SharePoint‑Timerservice om oplossingsgegevens over de farm te repliceren. Als deze services niet draaien op uw serverfarm, moet u de licentie mogelijk op elke server implementeren.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

Op SharePoint 2010 en later komen de SharePoint Management Shell‑cmdlets `Add-SPSolution`, `Install-SPSolution` en `Start-SPAdminJob` overeen met de `addsolution`, `deploysolution` en `execadmsvcjobs`‑operaties. Zie [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **De licentie testen**

Om te testen of de licentie correct is geïnstalleerd, converteer een willekeurige presentatie naar een nieuw formaat. Als er geen evaluatiewatermerk in het geconverteerde bestand staat, is de licentie actief.