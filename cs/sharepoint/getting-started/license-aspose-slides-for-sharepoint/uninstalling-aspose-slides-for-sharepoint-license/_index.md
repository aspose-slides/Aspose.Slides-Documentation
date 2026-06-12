---
title: Odinstalování licence Aspose.Slides pro SharePoint
type: docs
weight: 20
url: /cs/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Chcete-li odinstalovat licenci, použijte níže uvedené kroky z konzole serveru.

1. Odeberte licenční řešení ze farmy:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Proveďte administrativní časově naplánované úlohy, aby byl odebrání dokončeno okamžitě:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Počkejte, až se odebrání dokončí. Můžete použít Central Administration a zkontrolovat, zda bylo odebrání dokončeno pod **Central Administration**, poté **Operations** a **Solution Management**.
4. Odeberte řešení ze skladu řešení SharePointu:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```