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
description: "Lär dig om förtroendekrav, behörigheter och värdbegränsningar för Aspose.Slides för Java så att du säkert kan distribuera appar som behandlar PPT, PPTX och ODP på servrar."
---
{{% alert color="primary" %}} 

Alla Aspose Java-komponenter kräver behörighetsuppsättningen Full Trust. Anledningen är att Aspose Java-komponenter behöver åtkomst till registerinställningar, systemfiler utöver den virtuella katalogen för vissa operationer som att parsra teckensnitt etc. Dessutom är Aspose Java-komponenter baserade på kärn-Java-systemklasser som också i många fall kräver behörighetsuppsättningen Full Trust. 

{{% /alert %}} 

Internetleverantörer som är värdar för flera applikationer från olika företag upprätthåller oftast säkerhetsnivån Medium Trust: 

- OleDbPermission är inte tillgänglig. Detta innebär att du inte kan använda den hanterade OLE DB-dataleverantören i ADO.NET för att komma åt databaser.
- EventLogPermission är inte tillgänglig. Detta innebär att du inte kan komma åt Windows händelselogg.
- ReflectionPermission är inte tillgänglig. Detta innebär att du inte kan använda reflektion.
- RegistryPermission är inte tillgänglig. Detta innebär att du inte kan komma åt registret.
- WebPermission är begränsad. Detta innebär att din applikation bara kan kommunicera med en adress eller ett adressintervall som du definierar i <trust>-elementet.
- FileIOPermission är begränsad. Detta innebär att du bara kan komma åt filer i din applikations virtuella kataloghierarki.

{{% alert color="primary" %}} 

På grund av de ovan angivna skälen kan Aspose Java-komponenter inte användas på servrar som tilldelar en behörighetsuppsättning annan än Full Trust. 

{{% /alert %}}