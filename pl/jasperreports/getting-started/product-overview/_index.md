---
title: Przegląd produktu
type: docs
weight: 10
url: /pl/jasperreports/product-overview/
description: "Dowiedz się, co robi Aspose.Slides for JasperReports, które wersje JasperReports i formaty wyjściowe obsługuje oraz do czego służą jego dwa pliki JAR."
---
![Aspose.Slides dla JasperReports](product-overview_1.png)

## **Opis produktu**

Aspose.Slides for JasperReports eksportuje raporty z JasperReports do prezentacji PowerPoint, w aplikacjach Java i w JasperReports Server, bez potrzeby posiadania Microsoft PowerPoint. Obsługuje JasperReports 3.7.2‑6.16.0, z oddzielnym plikiem JAR dla każdego zakresu wersji — zobacz [Instalowanie Aspose.Slides for JasperReports](/slides/pl/jasperreports/installing-aspose-slides-for-jasperreports/).

Eksportuje wypełniony raport do czterech formatów, po jednym slajdzie lub stronie na każdą stronę raportu:

- PPT – prezentacja PowerPoint 97–2003
- PPTX – prezentacja PowerPoint (Office Open XML)
- PDF
- HTML

Produkt składa się z dwóch części:

- Plik JAR biblioteki dodaje eksportery `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` i `ASHtmlExporter` do biblioteki JasperReports.
- Plik JAR serwera udostępnia akcje eksportu dla tych samych czterech formatów, które rejestrujesz w JasperReports Server — zobacz [Integracja z JasperServer](/slides/pl/jasperreports/integration-with-jasperserver/).

### **Przykład wyjścia**

Eksportery rozszerzają własne klasy eksporterów JasperReports i są używane w ten sam sposób: przekazujesz im wypełniony raport i plik wyjściowy, a następnie wywołujesz `exportReport`. Pełny program, który wypełnia raport i eksportuje go do PPTX, znajdziesz w [Twój pierwszy eksport](/slides/pl/jasperreports/#your-first-export); dla wszystkich czterech formatów zobacz [Eksport PPT, PPTX, PDF i HTML](/slides/pl/jasperreports/ppt-pptx-pdf-and-html-export/).

![Raport wyeksportowany do prezentacji bez licencji, z znakiem wodnym oceny w środku slajdu](product-overview_2.png)