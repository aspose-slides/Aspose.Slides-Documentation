---
title: Απεγκατάσταση άδειας Aspose.Slides για SharePoint
type: docs
weight: 20
url: /el/sharepoint/uninstalling-aspose-slides-for-sharepoint-license/
---
Για να απεγκαταστήσετε την άδεια, παρακαλούμε ακολουθήστε τα παρακάτω βήματα από την κονσόλα του διακομιστή. 

1. Ανακαλέστε τη λύση άδειας από το farm: 

``` xml

 stsadm.exe -o retractsolution -name Aspose.Slides.SharePoint.License.wsp -immediate

```

2. Εκτελέστε τις διαχειριστικές εργασίες χρονομέτρου για να ολοκληρωθεί η ανάκληση αμέσως: 

``` xml

 stsadm.exe -o execadmsvcjobs

```

3. Περιμένετε να ολοκληρωθεί η ανάκληση. Μπορείτε να χρησιμοποιήσετε τη Central Administration για να ελέγξετε εάν η ανάκληση ολοκληρώθηκε κάτω από **Central Administration**, έπειτα **Operations** και **Solution Management**.
4. Αφαιρέστε τη λύση από το αποθετήριο λύσεων του SharePoint: 

``` xml

 stsadm.exe -o deletesolution -name Aspose.Slides.SharePoint.License.wsp

```