---
title: Odinstalowywanie licencji Aspose.Slides dla SharePoint
type: docs
weight: 20
url: /pl/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Aby odinstalować licencję, użyj poniższych kroków z konsoli serwera. 

1. Wycofaj rozwiązanie licencyjne z farmy: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Uruchom zadania timera administracyjnego, aby natychmiast zakończyć wycofanie: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Poczekaj, aż wycofanie się zakończy. Możesz użyć Central Administration, aby sprawdzić, czy wycofanie zakończyło się, w sekcji **Central Administration**, a następnie **Operations** i **Solution Management**.
4. Usuń rozwiązanie ze sklepu rozwiązań SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```