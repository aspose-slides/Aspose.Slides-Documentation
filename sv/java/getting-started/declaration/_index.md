---
title: Deklaration
type: docs
weight: 60
url: /sv/java/declaration/
keywords:
- deklaration
- komponenter
- Full Trust-behörighet
- registerinställningar
- systemfiler
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig om förtroendekrav, behörigheter och hostingbegränsningar för Aspose.Slides för Java så att du säkert kan distribuera appar som bearbetar PPT, PPTX och ODP på servrar."
---
{{% alert color="info" %}} 

Alla Aspose Java-komponenter kräver Full Trust-behörighetsuppsättning. Anledningen är att Aspose Java-komponenter måste komma åt registerinställningar, systemfiler utöver den virtuella katalogen för vissa operationer som att analysera teckensnitt etc. Dessutom är Aspose Java-komponenter baserade på kärn‑Java‑systemklasser som också i många fall kräver Full Trust-behörighetsuppsättning. 

{{% /alert %}} 

Internetleverantörer som hostar flera applikationer från olika företag tillämpar vanligtvis säkerhetsnivån Medium Trust: 

- OleDbPermission är inte tillgänglig. Detta innebär att du inte kan använda den hanterade OLE DB-dataleverantören i ADO.NET för att komma åt databaser.
- EventLogPermission är inte tillgänglig. Detta innebär att du inte kan komma åt Windows händelselogg.
- ReflectionPermission är inte tillgänglig. Detta innebär att du inte kan använda reflektion.
- RegistryPermission är inte tillgänglig. Detta innebär att du inte kan komma åt registret.
- WebPermission är begränsad. Detta innebär att din applikation bara kan kommunicera med en adress eller ett adressintervall som du definierar i <trust>-elementet.
- FileIOPermission är begränsad. Detta innebär att du bara kan komma åt filer i din applikations virtuella kataloghierarki.

{{% alert color="info" %}} 

På grund av ovanstående skäl kan inte Aspose Java-komponenter användas på servrar som beviljar en behörighetsuppsättning annat än Full Trust. 

{{% /alert %}}