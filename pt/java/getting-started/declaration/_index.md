---
title: Declaração
type: docs
weight: 60
url: /pt/java/declaration/
keywords:
- declaração
- componentes
- permissão Full Trust
- configurações de registro
- arquivos do sistema
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Aprenda sobre os requisitos de confiança, permissões e limitações de hospedagem do Aspose.Slides for Java para que você possa implantar com segurança aplicativos que processam PPT, PPTX e ODP em servidores."
---
{{% alert color="info" %}} 

Todos os componentes Aspose Java requerem o conjunto de permissões Full Trust. O motivo é que os componentes Aspose Java precisam acessar configurações de registro, arquivos do sistema além do diretório virtual para determinadas operações, como análise de fontes etc. Além disso, os componentes Aspose Java são baseados em classes centrais do sistema Java que também exigem o conjunto de permissões Full Trust em muitos casos. 

{{% /alert %}} 

Provedores de Internet que hospedam múltiplas aplicações de diferentes empresas geralmente impõem o nível de segurança Medium Trust: 

- OleDbPermission não está disponível. Isso significa que você não pode usar o provedor de dados OLE DB gerenciado do ADO.NET para acessar bancos de dados.
- EventLogPermission não está disponível. Isso significa que você não pode acessar o log de eventos do Windows.
- ReflectionPermission não está disponível. Isso significa que você não pode usar reflexão.
- RegistryPermission não está disponível. Isso significa que você não pode acessar o registro.
- WebPermission é restrito. Isso significa que sua aplicação só pode se comunicar com um endereço ou intervalo de endereços que você definir no elemento <trust>.
- FileIOPermission é restrito. Isso significa que você só pode acessar arquivos na hierarquia de diretórios virtuais da sua aplicação.

{{% alert color="info" %}} 

Devido aos motivos especificados acima, os componentes Aspose Java não podem ser usados em servidores que concedem um conjunto de permissões diferente de Full Trust. 

{{% /alert %}}