---
title: Deklarace
type: docs
weight: 60
url: /cs/php-java/declaration/
keywords:
- deklarace
- komponenty
- oprávnění Full Trust
- nastavení registru
- systémové soubory
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Zjistěte informace o požadavcích na důvěru, oprávněních a omezeních hostování Aspose.Slides pro PHP, abyste mohli bezpečně nasazovat aplikace zpracovávající PPT, PPTX a ODP na serverech."
---
{{% alert color="primary" %}} 

Všechny komponenty Aspose Java vyžadují oprávnění Full Trust. Důvod je, že komponenty Aspose Java potřebují přístup k nastavením registru, systémovým souborům mimo virtuální adresář pro některé operace, jako je parsování fontů apod. Navíc jsou komponenty Aspose Java založeny na základních třídách systému Java, které v mnoha případech také vyžadují oprávnění Full Trust.

{{% /alert %}} 

Internet Service Providers, kteří hostují více aplikací od různých společností, většinou vynucují úroveň zabezpečení Medium Trust:

- OleDbPermission není k dispozici. To znamená, že nemůžete použít spravovaného poskytovatele dat ADO.NET OLE DB k přístupu k databázím.
- EventLogPermission není k dispozici. To znamená, že nemáte přístup k protokolu událostí Windows.
- ReflectionPermission není k dispozici. To znamená, že nemůžete používat reflexi.
- RegistryPermission není k dispozici. To znamená, že nemáte přístup k registru.
- WebPermission je omezený. To znamená, že vaše aplikace může komunikovat jen s adresou nebo rozsahem adres, které definujete v elementu <trust>.
- FileIOPermission je omezený. To znamená, že můžete přistupovat jen k souborům ve virtuální adresářové hierarchii vaší aplikace.

{{% alert color="primary" %}} 

Z důvodů uvedených výše nemohou být komponenty Aspose Java použity na serverech, které poskytují oprávnění jiná než Full Trust.

{{% /alert %}}