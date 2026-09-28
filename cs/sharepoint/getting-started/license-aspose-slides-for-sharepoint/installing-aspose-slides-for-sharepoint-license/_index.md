---
title: Instalace licence Aspose.Slides pro SharePoint
type: docs
weight: 10
url: /cs/sharepoint/installing-aspose-slides-for-sharepoint-license/
description: "Nainstalujte licenci Aspose.Slides pro SharePoint na farmu SharePoint: přidejte řešení licence do úložiště řešení, nasadíte jej a ověřte, že převedené soubory již neobsahují vodotisk hodnocení."
---
{{% alert color="info" title="Note" %}}

Jakmile budete spokojeni s hodnocením, můžete [zakoupit licenci](https://purchase.aspose.com/pricing/slides/sharepoint/). Před nákupem se ujistěte, že rozumíte podmínkám předplatného licence a souhlasíte s nimi. Licence vám bude zaslána e‑mailem po zaplacení objednávky.

Licence je archiv ZIP obsahující běžný balíček řešení SharePoint. Archiv obsahuje:

- Aspose.Slides.SharePoint.License.wsp – soubor balíčku řešení SharePoint. Licence je zabalena jako řešení SharePoint, aby bylo nasazení a stažení napříč farmou serverů snadné.
- readme.txt – Pokyny k instalaci licence.

{{% /alert %}}

## **Nasazení licence**

Instalace licence se provádí z konzole serveru pomocí **stsadm.exe**.

{{% alert color="info" title="Note" %}}

Cesty jsou v následující části vynechány pro přehlednost.

{{% /alert %}}

Proveďte následující kroky k nasazení licence Aspose.Slides pro SharePoint:

1. Spusťte stsadm pro přidání řešení do úložiště řešení SharePoint:

   ```bat
   Stsadm.exe -o addsolution -filename Aspose.Slides.SharePoint.License.wsp
   ```

2. Nasazujte řešení na všechny servery ve farmě:

   ```bat
   Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force
   ```

3. Proveďte administrativní časovačové úlohy pro okamžité dokončení nasazení:

   ```bat
   Stsadm.exe -o execadmsvcjobs
   ```

Operace `addsolution` přijímá cestu k souboru řešení v `-filename`; operace `deploysolution` přijímá název řešení, které je již v úložišti řešení, v `-name`.

{{% alert color="info" title="Note" %}}

Při spuštění kroku nasazení se zobrazí varování, pokud služba SharePoint Administration neběží. **stsadm.exe** závisí na této službě a na službě SharePoint Timer, aby replikovala data řešení napříč farmou. Pokud tyto služby neběží na vaší farmě serverů, může být nutné licenci nasadit na každém serveru zvlášť.

{{% /alert %}}

{{% alert color="info" title="Note" %}}

V SharePoint 2010 a novějších odpovídají cmdlety SharePoint Management Shell `Add-SPSolution`, `Install-SPSolution` a `Start-SPAdminJob` operacím `addsolution`, `deploysolution` a `execadmsvcjobs`. Viz [Mapování Stsadm na Microsoft PowerShell v SharePoint Serveru](https://learn.microsoft.com/en-us/sharepoint/technical-reference/stsadm-to-microsoft-powershell-mapping).

{{% /alert %}}

## **Otestování licence**

Pro otestování, že byla licence nainstalována správně, převeďte libovolnou prezentaci do nového formátu. Pokud v převedeném souboru není vodotisk hodnocení, licence je aktivní.