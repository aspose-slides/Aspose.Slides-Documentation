---
title: Declaração
type: docs
weight: 60
url: /pt/java/declaration/
keywords:
- declaração
- componentes
- permissão Full Trust
- configurações do registro
- arquivos do sistema
- PowerPoint
- OpenDocument
- apresentação
- Java
- Aspose.Slides
description: "Saiba sobre os requisitos de confiança, permissões e limitações de hospedagem do Aspose.Slides for Java, para que você possa implantar com segurança aplicativos que processam PPT, PPTX e ODP em servidores."
---
{{% alert color="primary" %}}
Todos os componentes Aspose Java exigem o conjunto de permissões Full Trust. O motivo é que os componentes Aspose Java precisam acessar configurações do registro, arquivos do sistema fora do diretório virtual para certas operações, como análise de fontes etc. Além disso, os componentes Aspose Java são baseados em classes principais do sistema Java que também requerem o conjunto de permissões Full Trust em muitos casos.
{{% /alert %}}
Provedores de Serviços de Internet que hospedam múltiplas aplicações de diferentes empresas normalmente aplicam o nível de segurança Medium Trust:
- OleDbPermission não está disponível. Isso significa que você não pode usar o provedor de dados OLE DB gerenciado do ADO.NET para acessar bancos de dados.
- EventLogPermission não está disponível. Isso significa que você não pode acessar o log de eventos do Windows.
- ReflectionPermission não está disponível. Isso significa que você não pode usar reflexão.
- RegistryPermission não está disponível. Isso significa que você não pode acessar o registro.
- WebPermission é restrita. Isso significa que sua aplicação só pode se comunicar com um endereço ou intervalo de endereços que você definir no elemento <trust>.
- FileIOPermission é restrita. Isso significa que você só pode acessar arquivos na hierarquia de diretórios virtuais da sua aplicação.
{{% alert color="primary" %}}
Devido aos motivos especificados acima, os componentes Aspose Java não podem ser usados em servidores que concedem um conjunto de permissões diferente de Full Trust.
{{% /alert %}}