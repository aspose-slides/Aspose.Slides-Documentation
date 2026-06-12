---
title: Disinstallazione della licenza Aspose.Slides per SharePoint
type: docs
weight: 20
url: /it/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Per disinstallare la licenza, utilizzare i passaggi seguenti dalla console del server.

1. Ritirare la soluzione della licenza dalla farm:

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Eseguire i job timer amministrativi per completare immediatamente il ritiro:

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Attendere il completamento del ritiro. È possibile utilizzare Central Administration per verificare se il ritiro è stato completato sotto **Central Administration**, poi **Operations** e **Solution Management**.
4. Rimuovere la soluzione dallo store delle soluzioni di SharePoint:

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```