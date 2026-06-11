---
title: Avinstallera Aspose.Slides för SharePoint-licens
type: docs
weight: 20
url: /sv/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
För att avinstallera licensen, använd stegen nedan från serverkonsolen. 

1. Återkalla licenslösningen från farmen: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Kör administrativa timer-jobb för att slutföra återkallelsen omedelbart: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Vänta på att återkallelsen ska slutföras. Du kan använda Central Administration för att kontrollera om återkallelsen är klar under **Central Administration**, sedan **Operations** och **Solution Management**.
4. Ta bort lösningen från SharePoints lösningslager: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```