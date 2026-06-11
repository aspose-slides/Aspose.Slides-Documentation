---
title: Utrullning och aktivering
type: docs
weight: 20
url: /sv/sharepoint/deployment-and-activation/
---
## **Utrullning**
Under utrullning, Aspose.Slides for SharePoint: 

- Installerar **Aspose.Slides.SharePoint.dll** i Global Assembly Cache och lägger till en SafeControl‑post i **web.config**‑filen.
- Installerar funktionsmanifestet och andra nödvändiga filer till lämpliga kataloger.
- Registrerar funktionen i SharePoint‑databasen och gör den tillgänglig för aktivering på funktionsnivå.
## **Aktivering**
Aspose.Slides for SharePoint paketeras som en funktionsnivå på webbplats (webbplatskollektion) och kan aktiveras eller inaktiveras på webbplatskollektioner. Under aktivering gör funktionen vissa ändringar i den virtuella katalogen för den överordnade webbapplikationen för webbplatskollektionen. Den: 

- Lägger till konverteringsinställningssidan i sitemap‑filen.
- Kopierar de nödvändiga resursfilerna till mappen App_GlobalResources i den virtuella katalogen.