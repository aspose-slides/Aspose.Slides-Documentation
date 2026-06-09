---
title: Μετατροπή παρουσιάσεων OpenDocument σε C++
linktitle: Μετατροπή OpenDocument
type: docs
weight: 10
url: /el/cpp/convert-openoffice-odp/
keywords:
- μετατροπή ODP
- ODP σε εικόνα
- ODP σε GIF
- ODP σε HTML
- ODP σε JPG
- ODP σε MD
- ODP σε PDF
- ODP σε PNG
- ODP σε PPT
- ODP σε PPTX
- ODP σε TIFF
- ODP σε βίντεο
- ODP σε Word
- ODP σε XPS
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Το Aspose.Slides για C++ σας επιτρέπει να μετατρέπετε ODP σε PDF, HTML και μορφές εικόνας με ευκολία. Ενισχύστε τις C++ εφαρμογές σας με γρήγορη και ακριβή μετατροπή παρουσιάσεων."
---
[**Aspose.Slides API**](https://products.aspose.com/slides/el/cpp/) σας επιτρέπει να μετατρέψετε παρουσιάσεις OpenDocument (ODP) σε πολλές μορφές (HTML, PDF, TIFF, SWF, XPS, κλπ.). Το API που χρησιμοποιείται για τη μετατροπή αρχείων ODP σε άλλες μορφές εγγράφων είναι το ίδιο με αυτό που χρησιμοποιείται για λειτουργίες μετατροπής PowerPoint (PPT και PPTX).

Για παράδειγμα, εάν χρειάζεστε να μετατρέψετε μια παρουσίαση ODP σε PDF, μπορείτε να το κάνετε ως εξής:

```cpp
auto pres = MakeObject<Presentation>(u"pres.odp");
pres->Save(u"pres.pdf", SaveFormat::Pdf);
pres->Dispose();
```