---
title: Telepítés és aktiválás
type: docs
weight: 20
url: /hu/sharepoint/deployment-and-activation/
description: "Mi az, amit az Aspose.Slides for SharePoint megoldás telepít a farmra telepítéskor, és mit ad hozzá a webhelygyűjtemény-funkciója aktiváláskor."
---
## **Telepítés**

Telepítés során az Aspose.Slides for SharePoint megoldás:

- Telepíti az összeállítását a Global Assembly Cache-be, és SafeControl bejegyzéseket ad hozzá a **web.config** fájlhoz. A SharePoint 2010‑tól kezdődően ez a *Aspose.Slides.SharePoint2010.dll*, *Aspose.Slides.SharePoint2013.dll* vagy *Aspose.Slides.SharePoint2016.dll* (a SharePoint 2019 csomag szintén telepíti a *Aspose.Slides.SharePoint2016.dll*-t). A SharePoint 2007 esetén ez a *Aspose.Slides.SharePointUI.dll*, együtt a *Aspose.Slides.SharePoint.Deployment.dll*-val.
- Átmásolja a konverziós oldalt, annak képeit és egyéb támogató fájlokat a SharePoint telepítési mappákba.
- Telepíti a funkciót, és elérhetővé teszi annak aktiválását a webhelygyűjteményekben.

## **Aktiválás**

Az Aspose.Slides for SharePoint webhelygyűjtemény-funkcióként van csomagolva, és aktiválható vagy deaktiválható a webhelygyűjteményeken. Amikor egy webhelygyűjteményen aktiválva van, a funkció hozzáadja:

- **SharePoint 2010‑tól kezdődően:**
  - a **Convert via Aspose.Slides** elemet a dokumentumtárak dokumentummenüjéhez;
  - az **Aspose Tools** szalagfület a **Convert Slides** gombbal, amely konvertálja a kiválasztott dokumentumokat;
  - a **View Slides** elemet a PPT, PPTX, PPS és PPSX fájlok menüjéhez.
- **SharePoint 2007‑nél:**
  - a **Convert with Aspose.Slides** elemet a dokumentumtárak dokumentummenüjéhez;
  - a **Convert All with Aspose.Slides** elemet a dokumentumtárak **Actions** menüjéhez.

SharePoint 2007‑nél az aktiválás módosításokat is végez a webhelygyűjtemény szülő webalkalmazásának virtuális könyvtárában. Ez:

- Hozzáadja a konverziós beállítások oldalt a sitemap fájlhoz.
- Átmásolja a szükséges erőforrás-fájlokat a virtuális könyvtár App_GlobalResources mappájába.

A telepítőprogram aktiválja a funkciót a webhelygyűjteményeken, amelyeket a [telepítés](/slides/hu/sharepoint/installing-aspose-slides-for-sharepoint/) során választ.