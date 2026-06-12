---
title: Nasazení a aktivace
type: docs
weight: 20
url: /cs/sharepoint/deployment-and-activation/
---
## **Deployment**
Během nasazení, Aspose.Slides for SharePoint: 

- Instaluje **Aspose.Slides.SharePoint.dll** do Global Assembly Cache a přidá položku SafeControl do souboru **web.config**.
- Instaluje manifest funkce a další nezbytné soubory do odpovídajících adresářů.
- Zaregistruje funkci v databázi SharePoint a zpřístupní ji pro aktivaci v rozsahu funkce.
## **Activation**
Aspose.Slides for SharePoint je zabalen jako funkce úrovně webu (site collection) a může být aktivována nebo deaktivována na kolekcích webů. Během aktivace provede funkce některé změny ve virtuálním adresáři nadřazené webové aplikace kolekce webů. Provádí: 

- Přidá stránku nastavení konverze do souboru sitemap.
- Zkopíruje nezbytné soubory zdrojů do složky App_GlobalResources ve virtuálním adresáři.