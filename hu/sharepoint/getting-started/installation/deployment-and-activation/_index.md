---
title: Telepítés és aktiválás
type: docs
weight: 20
url: /hu/sharepoint/deployment-and-activation/
---
## **Telepítés**
Telepítés során az Aspose.Slides for SharePoint: 

- Telepíti az Aspose.Slides.SharePoint.dll-et a Global Assembly Cache-be, és hozzáad egy SafeControl bejegyzést a web.config fájlhoz.
- Telepíti a funkciómanifestet és a többi szükséges fájlt a megfelelő könyvtárakba.
- Regisztrálja a funkciót a SharePoint adatbázisban, és elérhetővé teszi a funkciókört aktiváláshoz.
## **Aktiválás**
Az Aspose.Slides for SharePoint egy webhely (site collection) szintű funkcióként van csomagolva, és aktiválható vagy deaktiválható webhelygyűjteményeken. Aktiváláskor a funkció módosításokat hajt végre a webhelygyűjtemény szülő webalkalmazásának virtuális könyvtárában. Ez: 

- Hozzáadja a konverziós beállítások oldalát a sitemap fájlhoz.
- Átmásolja a szükséges erőforrásfájlokat az App_GlobalResources mappába a virtuális könyvtárban.