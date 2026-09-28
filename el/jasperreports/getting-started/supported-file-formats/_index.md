---
title: Υποστηριζόμενες μορφές αρχείων
type: docs
weight: 20
url: /el/jasperreports/supported-file-formats/
description: "Δείτε τι δέχεται ως είσοδο το Aspose.Slides for JasperReports και σε ποιες μορφές αρχείων εξάγει τις αναφορές."
---
## **Είσοδος**

Aspose.Slides for JasperReports εξάγει αναφορές· δεν μετατρέπει υπάρχουσες παρουσιάσεις. Οι εξαγωγείς του λαμβάνουν μια γεμάτη αναφορά JasperReports (`JasperPrint`), όπως το αποτέλεσμα του `JasperFillManager` ή μια γεμάτη αναφορά που φορτώθηκε από αρχείο *.jrprint*.

## **Μορφές εξόδου**

Ο παρακάτω πίνακας παραθέτει τις μορφές στις οποίες το Aspose.Slides for JasperReports εξάγει μια αναφορά, καθώς και την κλάση εξαγωγέα που γράφει την καθεμία.

|**Μορφή**|**Περιγραφή**|**Εξαγωγέας**|
| :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|Παρουσίαση PowerPoint 97–2003· μία διαφάνεια ανά σελίδα αναφοράς|`ASPptExporter`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|Παρουσίαση PowerPoint (Office Open XML)· μία διαφάνεια ανά σελίδα αναφοράς|`ASPptxExporter`|
|[PDF](https://docs.fileformat.com/pdf/)|Φορητό Έγγραφο (PDF)· μία σελίδα PDF ανά σελίδα αναφοράς|`ASPdfExporter`|
|[HTML](https://docs.fileformat.com/web/html/)|Ένα μοναδικό αρχείο HTML με μία εικόνα SVG ανά σελίδα αναφοράς|`ASHtmlExporter`|

Δεν υπάρχει εξαγωγέας για τις μορφές παρουσίασης PPS και PPSX. Η ανάθεση ενός ονόματος αρχείου *.ppsx* σε εξαγωγή PPTX παράγει ακόμη παρουσίαση PPTX, όχι παρουσίαση διαφάνειας. Για να δείτε πώς χρησιμοποιείται κάθε εξαγωγέας, δείτε [Εξαγωγή PPT, PPTX, PDF και HTML](/slides/el/jasperreports/ppt-pptx-pdf-and-html-export/).