---
title: Bevezetés és környezet beállítása
type: docs
weight: 10
url: /hu/reportingservices/introduction-and-environment-setup/
---
{{% alert color="primary" %}} 

Korábban voltak kérdések az Aspose.Slides a Reporting Services integrációjáról a SharePoint-tal kapcsolatban. Ebben a cikkben a SharePoint 2010-re fókuszálunk. Feltételezzük, hogy már rendelkezik egy SharePoint Farm környezettel. A példák, amelyeket ebben a cikkben követünk, egy teljes SharePoint felhőre vonatkoznak, de a lépések hasonlóak egy SharePoint Foundation Server esetén. Mielőtt folytatnánk, tekintsük át a következő kulcsfontosságú dokumentációkat, amelyeket hivatkozásként használhat:

- [Reporting Services és SharePoint technológiai integráció áttekintése](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Reporting Services konfigurálása a SharePoint 2010 integrációhoz](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Környezet beállítása**
A felállás, amit használni fogunk, **4 szerverből** áll. Ez magában foglal egy **Domain Controller**‑t, egy **SQL Server**‑t, egy **SharePoint Server**‑t és egy szervert a **Reporting Services**‑hez. Választhatja, hogy a SharePoint és a Reporting Services ugyanazon a gépen vannak.