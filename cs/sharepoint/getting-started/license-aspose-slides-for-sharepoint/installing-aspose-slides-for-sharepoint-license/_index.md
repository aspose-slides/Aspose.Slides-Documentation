---
title: Instalace licence Aspose.Slides pro SharePoint
type: docs
weight: 10
url: /cs/sharepoint/installing-aspose-slides-for-sharepoint-license/
---
{{% alert color="primary" %}} 

Jakmile budete spokojeni s vyzkoušením, můžete [purchase a license](https://purchase.aspose.com/buy). Před nákupem se ujistěte, že rozumíte a souhlasíte s podmínkami předplatného licence. Licence vám bude zaslána e-mailem po uhrazení objednávky.

Licence je archiv ZIP obsahující běžný balíček řešení SharePoint. Archiv obsahuje:

- Aspose.Slides.SharePoint.License.wsp – soubor balíčku řešení SharePoint. Licence je zabalena jako řešení SharePoint, aby bylo nasazení a stažení napříč farmou serverů snadné.
- readme.txt – Pokyny k instalaci licence.

{{% /alert %}} 
## **Nasazení licence**
Instalace licence se provádí z konzole serveru pomocí **stsadm.exe**.

{{% alert color="primary" %}} 

Cesty jsou v následující sekci vynechány pro přehlednost.

{{% /alert %}} 

Proveďte následující kroky k nasazení licence Aspose.Slides pro SharePoint:

1. Spusťte stsadm pro přidání řešení do úložiště řešení SharePoint: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp

```

2. Nasadit řešení na všechny servery ve farmě: 

``` xml

 Stsadm.exe -o deploysolution -name Aspose.Slides.SharePoint.License.wsp -immediate -force

```

3. Spusťte administrativní časovačové úlohy, aby se nasazení okamžitě dokončilo: 

``` xml

 Stsadm.exe -o execadmsvcjobs

```

{{% alert color="primary" %}} 

Při provádění nasazení se zobrazí varování, pokud služba Windows SharePoint Services Administration neběží. **stsadm.exe** závisí na této službě a na Windows SharePoint Timer Service pro replikaci dat řešení napříč farmou. Pokud tyto služby ve vaší farmě serverů neběží, může být nutné nasadit licenci na každém serveru. 

{{% /alert %}} 
## **Testování licence**
Pro otestování, že byla licence správně nainstalována, převeďte libovolný dokument do nového formátu. Pokud v dokumentu není žádná zkušební vodoznak, licence byla úspěšně aktivována.