---
title: 为什么不使用自动化
type: docs
weight: 170
url: /zh/net/why-not-automation/
keywords:
- 自动化
- Microsoft Office
- 比较
- 安全性
- 稳定性
- 可扩展性
- 功能
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解为何 Office 自动化对服务器和服务存在风险，并了解 Aspose.Slides 如何为 PowerPoint 和 OpenDocument 提供更安全、更快速的演示文稿处理。"
---
## **介绍**

Aspose 组件是自动化的更佳替代方案有几个原因。关键原因包括：

- 安全性
- 稳定性
- 可扩展性/速度
- 价格
- 功能

以下是对每个关键点的更详细说明。

## **重要问题**

我们在 Aspose 经常听到两个问题：

- 您的产品是否需要安装 Microsoft Office 才能运行？

简短而明确的答案是 **否**。

Aspose 组件是完全独立的，未与 Microsoft Corporation 关联、授权、赞助或获得任何形式的认可。

- 为什么我们应该使用 Aspose 产品而不是 Microsoft Office Automation？

首先，有很多[使用 Aspose.Slides 时可享受的优势](/slides/zh/net/product-overview/)。

其次，Microsoft 本身强烈 **建议不要** 在软件解决方案中使用 Office Automation。

## **安全性**
> “Office 应用程序从未设计用于服务器端使用，因此未考虑分布式组件面临的安全问题。Office 不会对传入请求进行身份验证，也不会防止您无意中运行宏，或从服务器端代码启动可能运行宏的另一个服务器。不要打开从匿名 Web 上传到服务器的文件！根据上次设置的安全设置，服务器可以在管理员或系统上下文中以完全权限运行宏，从而危害您的网络！此外，Office 使用许多客户端组件（如 Simple MAPI、WinInet、MSDAIPP），这些组件会缓存客户端身份验证信息以加快处理速度。如果在服务器端自动化 Office，单个实例可能为多个客户端提供服务，并且由于该会话已缓存身份验证信息，可能导致一个客户端使用另一个客户端的缓存凭据，从而通过冒充其他用户获得未授予的访问权限。”

Aspose 产品非常 **安全**。Aspose 组件在与所有 ASP.NET 应用程序相同的用户上下文中运行（在 ASPNET 用户下）。因此，Aspose 组件 **不** 构成安全风险。它们也不会消耗关键的系统资源。此外，当 Aspose 组件打开文档时，宏不会自动运行。Aspose 组件旨在让开发者创建、操作和保存 Office 文件。

{{% alert color="info" title="Note" %}}
Microsoft Office 软件包相关的任何风险均不适用于 Aspose 组件。
{{% /alert %}}

## **稳定性**
> “Office 2000、Office XP 和 Office 2003 使用 Microsoft Windows Installer (MSI) 技术，使终端用户的安装和自我修复更简便。MSI 引入了‘首次使用时安装’的概念，允许在运行时动态安装或配置功能（针对系统，或更常见的是针对特定用户）。在服务器端环境中，这既会降低性能，又会增加出现对话框的可能性，要求用户批准安装或提供相应的安装光盘。虽然此设计旨在提升 Office 作为终端用户产品的弹性，但 Office 对 MSI 功能的实现对服务器端环境而言适得其反。此外，Office 的整体稳定性在服务器端运行时无法得到保障，因为它并未为此类使用设计或测试。在网络服务器上将 Office 用作服务组件可能会降低该机器的稳定性，进而影响整个网络的稳定性。如果计划在服务器端自动化 Office，请尝试将程序隔离到一台专用计算机上，该计算机不影响关键功能，并且可以根据需要重新启动。”

由于 Aspose 组件打包为单个 DLL，用户无需安装任何额外部件即可正常工作。Aspose 组件仅供 .NET 应用程序使用，组件代码中没有任何需要等待人工响应的部分。

{{% alert color="info" title="Note" %}}
Aspose 组件已经过彻底测试并确认非常稳定。Aspose 组件被[公司](https://about.aspose.com/customers/)（例如 **Bank of America**）以及许多其他行业的领先组织使用。
{{% /alert %}}

## **可扩展性/速度**
> “服务器端组件需要高度可重入、支持多线程的 COM 组件，具有最小开销和对多个客户端的高吞吐量。Office 应用程序在几乎所有方面正好相反。它们是非可重入、基于 STA 的 Automation 服务器，设计上为单个客户端提供多样但资源密集的功能。作为服务器端解决方案，它们几乎没有可扩展性，而且对重要元素（如内存）的限制是固定的，无法通过配置更改。更重要的是，它们使用全局资源（如内存映射文件、全局加载项或模板以及共享 Automation 服务器），这会限制并发运行的实例数量，并在多客户端环境中导致竞争条件。计划同时运行多个 Office 应用程序实例的开发者需要考虑池化或序列化访问 Office 应用程序，以避免潜在的死锁或数据损坏。”

Aspose 组件具有极高的可扩展性并且运行速度极快。Office 应用程序并未设计用于同时被数百甚至数千用户使用，而 Aspose 组件正是为此而生。我们的组件是真正的 .NET 解决方案。

{{% alert color="info" title="Note" %}}
Aspose 组件的性能在单服务器（支撑单一应用）或负载均衡的 Web 环境（支撑企业级应用）中均表现 flawless。
{{% /alert %}}

## **价格**
在使用 Microsoft Office Automation 的情况下，必须为每台运行该应用的机器购买一份 Microsoft Office。虽然应用可能需要多次创建或操作 Office 文件，但此过程并不需要 Microsoft Office。

{{% alert color="info" title="Note" %}}
Aspose 提供非常[具成本效益](https://purchase.aspose.com/)且免版税的再分发许可证，允许部署到无限数量的用户，且无需担心授权问题。
{{% /alert %}}

在创建基于 Web 的应用时，需要牢记 Microsoft Office Automation 组件既没有针对服务器端解决方案的定价，也没有相应的授权方式。因此，使用 Microsoft Office 组件的 Web 应用没有合适的授权方案。而 Aspose 则为服务器端应用提供了同样[具成本效益](https://purchase.aspose.com/)的解决方案。

## **功能**
Aspose 组件提供了管理 Office 文件所需的一切，甚至更多。我们基于帮助开发者以最少的工作量实现最大成果的理念来设计这些组件。

{{% alert color="info" title="Note" %}}
与 Office Automation 不同，Aspose 组件提供了许多强大且省时的功能。
{{% /alert %}}

例如，[Aspose.Cells](https://products.aspose.com/cells/net/) 为开发者提供了直接将 **DataTable** 或 **DataView** 数据导入 Excel 文件的能力。[Aspose.Words](https://products.aspose.com/words/net/) 提供了类似功能，允许开发者直接从任意 .NET 数据对象填充 Word（即邮件合并）文档。Aspose 系列的[每个组件](https://products.aspose.com/total/net/)都有自己独特且强大的功能集。

购买 Aspose 组件的最大优势是可以获得我们开发团队的支持。例如，使用 Office Automation 对象并需要某些功能时，添加这些功能的可能性非常低。而 Aspose 组件则截然不同。

{{% alert color="info" title="Note" %}}
我们的开发团队理解，如果贵公司需要的功能，其他公司也很可能需要。虽然我们不可能实现所有请求的功能，但我们会根据客户反馈尽可能多地添加功能。
{{% /alert %}}

我们的团队在提供帮助时始终保持开放和灵活——这正是 Aspose 组件能够成长为如今如此强大的原因。

## **结论**
{{% alert color="info" title="Note" %}}
虽然本文已覆盖了 Aspose 组件优于 Office Automation 的一些关键点，但实际上还有更多优势。我们仅列举了一部分主要优势。

此外，所有 Aspose 产品和组件均提供无风险、无义务的[评估版](https://releases.aspose.com/slides/zh/net/)。我们鼓励您利用评估版，亲自体验 Aspose 能为您的应用或业务带来什么。
{{% /alert %}}