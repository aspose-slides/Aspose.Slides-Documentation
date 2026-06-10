---
title: Aspose.Slides for SharePoint licenc eltávolítása
type: docs
weight: 20
url: /hu/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
A licenc eltávolításához kérjük, kövesse az alábbi lépéseket a szerver konzolról.

1. Vonja vissza a licencmegoldást a farmról:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Futtassa az adminisztratív időzítő feladatokat a visszavonás azonnali befejezése érdekében:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Várja meg, amíg a visszavonás befejeződik. A **Central Administration** alatt, majd az **Operations** és **Solution Management** menüpontokban ellenőrizheti, hogy a visszavonás befejeződött-e.

4. Távolítsa el a megoldást a SharePoint megoldástárból:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```