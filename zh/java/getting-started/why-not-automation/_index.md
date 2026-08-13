---
title: 为什么不使用自动化
type: docs
weight: 50
url: /zh/java/why-not-automation/
keywords:
- 自动化
- Microsoft Office
- 比较
- 安全性
- 稳定性
- 可伸缩性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- Java
- Aspose.Slides
description: "发现Office自动化在服务器和服务中的风险，并了解Aspose.Slides如何为PowerPoint和OpenDocument提供更安全、更快速的演示文稿处理。"
---
## **介绍**

Aspose 组件作为自动化的更佳替代方案有多种原因。主要原因包括：

- 安全性
- 稳定性
- 可伸缩性/速度
- 价格
- 功能

下面对每个关键点进行更详细的说明。

## **重要问题**

在 Aspose 我们经常听到两个问题：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短且明确的答案是 **否**。

Aspose 组件完全独立，未与 Microsoft 公司关联、授权、赞助或以其他方式获得认可。

- 为什么要使用 Aspose 产品而不是 Microsoft Office 自动化？

首先，使用 Aspose.Slides 时可享受的优势请参见[使用 Aspose.Slides 时可享受的优势](/slides/zh/java/product-overview/)。

其次，Microsoft 本身强烈**建议不要**在软件解决方案中使用 Office 自动化。

## **安全性**

以下内容直接摘自 Microsoft 文章：

*"Office 应用程序从未设计用于服务器端使用，因此未考虑分布式组件面临的安全问题。Office 不会对传入请求进行身份验证，也无法防止您意外运行宏，或从服务器端代码启动可能运行宏的其他服务器。不要打开匿名 Web 上传到服务器的文件！根据最后设置的安全设置，服务器可能以管理员或系统上下文运行宏，拥有完整权限并危及您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件会缓存客户端身份验证信息以加快处理速度。如果在服务器端自动化 Office，单个实例可能为多个客户端提供服务，由于该会话的身份验证信息已被缓存，可能导致一个客户端使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授权的访问权限。"* 

Aspose 产品非常安全。Aspose 组件不会对关键系统资源构成潜在风险。并且，当文档由 Aspose 组件打开时，宏不会自动运行。Aspose 组件的设计目标是帮助开发者创建、操作和保存 Office 文件。与 Microsoft Office 套件相关的风险并不固有于 Aspose 组件。

## **稳定性**

以下内容直接摘自 Microsoft 文章：

*"Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer（MSI）技术，使终端用户的安装和自我修复更便捷。MSI 引入了“首次使用时安装”的概念，允许在运行时（针对系统或更常针对特定用户）动态安装或配置功能。在服务器端环境中，这既会降低性能，又会增加出现对话框的可能性，要求用户批准安装或提供相应的安装光盘。虽然此设计旨在提升 Office 作为终端用户产品的弹性，但 Office 对 MSI 功能的实现对服务器端环境而言适得其反。此外，由于 Office 并未针对服务器端使用进行设计或测试，其整体稳定性无法得到保证。在网络服务器上将 Office 用作服务组件可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果计划在服务器端自动化 Office，请尝试将程序隔离到一台专用计算机，以免影响关键功能，并在需要时能够重新启动。"* 

Aspose 组件经过严格测试，极其稳定。Aspose 组件已被[公司]((https://about.aspose.com/customers))如 **IBM**、**Hilton**、**Reader's Digest**、**Bank of America** 等众多企业采用。

## **可伸缩性/速度**

以下内容直接摘自 Microsoft 文章：

*"服务器端组件需要高度可重入、多线程的 COM 组件，具备最小开销和高吞吐量以服务多个客户端。Office 应用程序在几乎所有方面恰恰相反。它们是非可重入、基于 STA 的自动化服务器，旨在为单一客户端提供多样且资源密集的功能。作为服务器端解决方案，它们几乎不具备可伸缩性，并且在内存等关键元素上有固定限制，无法通过配置更改。更重要的是，它们使用全局资源（如内存映射文件、全局加载项或模板以及共享的自动化服务器），这会限制并发实例的数量，并在多客户端环境中导致竞争条件。计划同时运行多个 Office 应用实例的开发者需要考虑* ***Pooling*** *或* ***Serializing Access*** *以避免潜在的* ***Deadlocks*** *或* ***Data Corruption*** *。"* 

Aspose 组件高度可伸缩且速度极快。Office 应用未设计用于同时供数百乃至上千用户使用，而 Aspose 组件正是为此而生。我们的组件在单台服务器上、驱动单一应用或在负载均衡的 Web 表单中，都能无缝、可靠地支撑企业级应用。

## **价格**

当应用程序使用 Microsoft Office 自动化时，需要为每台运行该应用的机器购买一份 Microsoft Office。很多情况下，应用只需创建或操作 Office 文件，却并不要求用户拥有 Microsoft Office。Aspose 提供极具[性价比]((https://purchase.aspose.com/))且免版税的再分发许可，允许无限数量的用户部署，无需担心授权问题。

在创建基于 Web 的应用时，需要了解 Microsoft Office 自动化组件既未对服务器端解决方案定价，也未提供相应授权；因此，使用 Microsoft Office 组件的 Web 应用几乎没有合适的授权方案。Aspose 同样为服务器端应用提供了极具性价比的解决方案。

## **功能**

Aspose 组件提供管理 Office 文件所需的一切功能，甚至更多。它们的设计理念是让开发者以最少的工作量实现最大的成果。与 Office 自动化不同，Aspose 组件提供了众多强大且省时的功能。例如，[Aspose.Cells]((https://products.aspose.com/cells/java/)) 允许开发者直接将 **DataTable** 或 **DataView** 导入到 Excel 文件中。[Aspose.Words]((https://products.aspose.com/words/java/)) 提供类似功能，可让开发者填充 Word（邮件合并）文档。Aspose 家族中的[每个组件]((https://products.aspose.com/total/java/))都拥有自己独特而强大的功能。

购买 Aspose 组件（或类似 [Aspose.Total]((https://products.aspose.com/total/java/)) 的组件套件）的最大好处之一是可以获得我们开发团队的支持。我们的开发团队深知，若贵公司需要的某项功能，其他公司很可能也有相同需求。虽然并非所有功能请求都能实现，但我们的团队在提供帮助时始终保持开放和灵活的态度。这种思维方式帮助 Aspose 组件成为如今如此强大的产品。若您希望在 Office 自动化对象中获得额外功能，实现的可能性极低。

## **结论**
{{% alert color="info" %}} 

虽然本文已经覆盖了 Aspose 组件相较于 Office 自动化的众多关键优势，但事实上还有更多。本篇主要阐述了最关键的要点。所有不同的 Aspose 组件均提供免费、无义务的[评估版]((https://downloads.aspose.com/slides/zh/java))。我们鼓励您利用此评估版，亲自感受 Aspose 能为您的应用带来的价值。 

{{% /alert %}}