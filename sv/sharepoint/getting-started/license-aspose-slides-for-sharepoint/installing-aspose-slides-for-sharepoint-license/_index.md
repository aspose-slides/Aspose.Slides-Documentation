---
title: Installera Aspose.Slides för SharePoint-licens
type: docs
weight: 10
url: /sv/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

När du är nöjd med din utvärdering kan du [köpa en licens](https://purchase.aspose.com/buy). Innan du köper, se till att du förstår och godkänner licensprenumerationsvillkoren. Licensen skickas till dig via e‑post när beställningen har betalats.

Licensen är ett ZIP‑arkiv som innehåller ett vanligt SharePoint‑lösningspaket. Arkivet innehåller:

- Aspose.Slides.SharePoint.License.wsp – SharePoint‑lösningspaketfilen. Licensen är paketerad som en SharePoint‑lösning för att underlätta distribution och återtagning över en serverfarm.
- readme.txt – Instruktioner för licensinstallation.

{{% /alert %}} 
## **Deploying the License**
License installation is performed from the server console via **stsadm.exe**.

{{% alert color="primary" %}} 

Sökvägarna har utelämnats i följande avsnitt för tydlighetens skull.

{{% /alert %}} 

Utför följande steg för att distribuera Aspose.Slides för SharePoint‑licensen:

1. Kör stsadm för att lägga till lösningen i SharePoint‑lösningslagret: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Distribuera lösningen till alla servrar i farmen: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Kör administrativa timer‑jobb för att slutföra distributionen omedelbart: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Du får en varning när du kör distributionssteget om Windows SharePoint Services Administration‑tjänsten inte är igång. **stsadm.exe** är beroende av denna tjänst och Windows SharePoint Timer Service för att replikera lösningsdata över farmen. Om dessa tjänster inte körs i din serverfarm kan du behöva distribuera licensen på varje server. 

{{% /alert %}} 
## **Test the License**
För att testa att licensen har installerats korrekt, konvertera ett dokument till ett nytt format. Om det inte finns någon utvärderingsvattenstämpel i dokumentet har licensen aktiverats framgångsrikt.