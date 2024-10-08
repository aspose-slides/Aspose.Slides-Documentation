---
title: Deinstallation der Aspose.Slides für SharePoint Lizenz
type: docs
weight: 20
url: /de/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---

Um die Lizenz zu deinstallieren, verwenden Sie bitte die folgenden Schritte von der Serverkonsole. 

1. Ziehen Sie die Lizenzlösung aus dem Farm zurück: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Führen Sie administrative Timerjobs aus, um die Rücknahme sofort abzuschließen: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Warten Sie, bis die Rücknahme abgeschlossen ist. Sie können die zentrale Verwaltung verwenden, um zu prüfen, ob die Rücknahme unter **Zentrale Verwaltung**, dann **Betrieb** und **Lösungsverwaltung** abgeschlossen ist.
4. Entfernen Sie die Lösung aus dem SharePoint-Lösungsstore: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```