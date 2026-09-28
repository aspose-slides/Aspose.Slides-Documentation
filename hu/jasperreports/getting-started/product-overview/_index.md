---
title: Termékáttekintés
type: docs
weight: 10
url: /hu/jasperreports/product-overview/
description: "Ismerje meg, mit csinál az Aspose.Slides for JasperReports, mely JasperReports verziókat és kimeneti formátumokat támogat, és mire szolgálnak a két jar fájljai."
---
![Aspose.Slides for JasperReports](product-overview_1.png)

## **Termékleírás**

Az Aspose.Slides for JasperReports a JasperReports jelentéseket PowerPoint prezentációkká exportálja Java alkalmazásokban és a JasperReports Server‑ben, a Microsoft PowerPoint nélkül. Támogatja a JasperReports 3.7.2‑től 6.16.0‑ig terjedő verziókat, minden verziócsoporthoz külön jar fájlt – lásd az [Installing Aspose.Slides for JasperReports](/slides/hu/jasperreports/installing-aspose-slides-for-jasperreports/).

Exportál egy kitöltött jelentést négy formátumba, oldalanként egy diát vagy oldalt:

- PPT – PowerPoint 97–2003 prezentáció
- PPTX – PowerPoint prezentáció (Office Open XML)
- PDF
- HTML

A termék két részből áll:

- A könyvtári jar hozzáadja az `ASPptExporter`, `ASPptxExporter`, `ASPdfExporter` és `ASHtmlExporter` exportereket a JasperReports Library-hez.
- A szerver jar exportálási műveleteket biztosít ugyanazokra a négy formátumra, amelyeket a JasperReports Server‑ben regisztrálhat – lásd az [Integration with JasperServer](/slides/hu/jasperreports/integration-with-jasperserver/).

### **Kimeneti példa**

Az exporterek a JasperReports saját exportáló osztályait öröklik, és ugyanúgy használhatók: átadja nekik a kitöltött jelentést és a kimeneti fájlt, majd meghívja az `exportReport`-et. Egy komplett programhoz, amely kitölt egy jelentést és PPTX‑be exportálja, lásd a [Your first export](/slides/hu/jasperreports/#your-first-export); a négy formátumhoz egyaránt, lásd a [PPT, PPTX, PDF and HTML Export](/slides/hu/jasperreports/ppt-pptx-pdf-and-html-export/).

![Egy jelentés, amely licenc nélkül lett exportálva egy prezentációba, a középpontjában az értékelő vízjel látható](product-overview_2.png)