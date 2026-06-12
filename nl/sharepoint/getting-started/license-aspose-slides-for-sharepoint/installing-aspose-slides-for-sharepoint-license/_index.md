---
title: Installeren van Aspose.Slides voor SharePoint-licentie
type: docs
weight: 10
url: /nl/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Zodra u tevreden bent met uw evaluatie, kunt u [een licentie aanschaffen](https://purchase.aspose.com/buy). Voordat u koopt, zorg ervoor dat u de voorwaarden van de licentieabonnement begrijpt en accepteert. De licentie wordt naar u gemaild zodra de bestelling is betaald.

De licentie is een ZIP‑archief dat een standaard SharePoint‑oplossingspakket bevat. Het archief bevat:

- Aspose.Slides.SharePoint.License.wsp – het SharePoint‑oplossingspakketbestand. De licentie wordt verpakt als een SharePoint‑oplossing om implementatie en terugtrekking over een server‑farm eenvoudig te maken.
- readme.txt – Installatie‑instructies voor de licentie.

{{% /alert %}} 
## **Implementatie van de licentie**
De installatie van de licentie wordt uitgevoerd vanaf de serverconsole via **stsadm.exe**.

{{% alert color="primary" %}} 

De paden zijn in de volgende sectie weggelaten voor de duidelijkheid.

{{% /alert %}} 

Voer de volgende stappen uit om de Aspose.Slides voor SharePoint‑licentie te implementeren:

1. Voer stsadm uit om de oplossing toe te voegen aan de SharePoint‑oplossingsopslag: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Implementeer de oplossing op alle servers in de farm: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Voer de administratieve timer‑taken uit om de implementatie onmiddellijk te voltooien: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

U krijgt een waarschuwing tijdens het uitvoeren van de implementatiestap als de Windows SharePoint Services Administration‑service niet draait. **stsadm.exe** is afhankelijk van deze service en de Windows SharePoint Timer Service om oplossingsdata over de farm te repliceren. Als deze services niet draaien op uw server‑farm, moet u de licentie mogelijk op elke server afzonderlijk implementeren. 

{{% /alert %}} 
## **Test de licentie**
Om te testen of de licentie correct is geïnstalleerd, converteer een willekeurig document naar een nieuw formaat. Als er geen evaluatiewatermerk in het document staat, is de licentie succesvol geactiveerd.