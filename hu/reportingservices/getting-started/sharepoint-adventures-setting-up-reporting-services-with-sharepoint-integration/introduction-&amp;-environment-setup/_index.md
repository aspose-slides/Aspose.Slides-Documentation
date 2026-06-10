---
title: Bevezetés és környezet beállítása
type: docs
weight: 10
url: /hu/reportingservices/introduction-&amp;-environment-setup/
---
{{% alert color="primary" %}} 

Korábban voltak kérdések az Aspose.Slides for Reporting Services integrációjáról a SharePointtal kapcsolatban. Ebben a cikkben a SharePoint 2010-re koncentrálunk. Feltételezzük, hogy már rendelkezik egy SharePoint Farm környezettel. A cikkben követendő példák egy teljes SharePoint Cloudot mutatnak, de a lépések hasonlóak lesznek egy SharePoint Foundation Server esetén. Mielőtt folytatnánk, kezdjünk néhány kulcsfontosságú dokumentációval, amelyet hivatkozásként használhat:

- [Reporting Services és SharePoint technológiai integráció áttekintése](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb326358(v=sql.105))
- [Reporting Services beállítása a SharePoint 2010 integrációhoz](https://docs.microsoft.com/en-us/previous-versions/sql/)

{{% /alert %}} 
#### **Környezet beállítása**
A beállítás, amelyet használni fogunk, **4 szerverből** áll. Ez magában foglal egy **Domain Controller**‑t, egy **SQL Server**‑t, egy **SharePoint Server**‑t és egy **Reporting Services** szervert. Választhatja, hogy a SharePoint‑ot és a Reporting Services‑t ugyanazon a gépen helyezi el.