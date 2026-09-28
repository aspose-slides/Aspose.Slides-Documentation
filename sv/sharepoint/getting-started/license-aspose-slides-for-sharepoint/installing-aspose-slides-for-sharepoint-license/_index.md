---
title: Installera Aspose.Slides för SharePoint-licens
type: docs
weight: 10
url: /sv/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Installera Aspose.Slides för SharePoint-licensen på en SharePoint-farm: lägg till licenslösningen i lösningslagret, distribuera den och kontrollera att konverterade filer inte längre innehåller utvärderingsvattenstämpeln."
---
{{% alert color="info" title="Obs" %}}

När du är nöjd med din utvärdering kan du [köpa en licens](https://purchase.aspose.com/pricing/slides/sharepoint/). Innan du köper, se till att du förstår och accepterar licensabonnemangsvillkoren. Licensen skickas till dig via e‑post när beställningen har betalats.

Licensen är ett ZIP‑arkiv som innehåller ett standard SharePoint‑lösningspaket. Arkivet innehåller:

- Aspose.Slides.SharePoint.License.wsp – SharePoint‑lösningspaketfilen. Licensen är paketerad som en SharePoint‑lösning för att göra distribution och återtagning över en serverfarm enkel.
- readme.txt – Installationsinstruktioner för licensen.

{{% /alert %}}

## **Distribuera licensen**

Licensinstallationen utförs från serverkonsolen via **stsadm.exe**.

{{% alert color="info" title="Obs" %}}

Sökvägarna har utelämnats i avsnittet nedan för tydlighetens skull.

{{% /alert %}}

Följ dessa steg för att distribuera Aspose.Slides för SharePoint‑licensen:

1. Kör stsadm för att lägga till lösningen i SharePoint‑lösningslagret:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Distribuera lösningen till alla servrar i farmen:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Kör administrativa timer‑jobb för att slutföra distributionen omedelbart:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Operationen `addsolution` tar sökvägen till lösningsfilen i `-filename`; operationen `deploysolution` tar namnet på den lösning som redan finns i lösningslagret i `-name`.

{{% alert color="info" title="Obs" %}}

Du får en varning när du kör distributionssteget om SharePoint‑administrationsservicen inte är igång. **stsadm.exe** förlitar sig på den här tjänsten och SharePoint Timer‑tjänsten för att replikera lösningsdata över farmen. Om dessa tjänster inte körs i din serverfarm kan du behöva distribuera licensen på varje server.

{{% /alert %}}

{{% alert color="info" title="Obs" %}}

I SharePoint 2010 och senare motsvarar SharePoint Management Shell‑cmdlets `Add-SPSolution`, `Install-SPSolution` och `Start-SPAdminJob` operationerna `addsolution`, `deploysolution` och `execadmsvcjobs`. Se [Stsadm to Microsoft PowerShell mapping in SharePoint Server](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Testa licensen**

För att testa att licensen har installerats korrekt, konvertera någon presentation till ett nytt format. Om det inte finns någon utvärderingsvattenstämpel i den konverterade filen är licensen aktiv.