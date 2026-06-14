---
title: 常見問題
type: docs
weight: 110
url: /zh-hant/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

此頁面彙集了多個關於以下主題的常見問題：

- [支援的檔案格式](#Supported-File-Formats).
- [支援 Power BI 報表服務](#Support-for-Power-BI-Reporting-services).
- [安裝](#Installation).
- [匯出設定](#Export-Configuration).

{{% /alert %}} 
### **支援的檔案格式**
#### **Q: 使用 Aspose.Slides for Reporting Services 時，可將報告匯出為哪些格式？**
**A**: Aspose.Slides for Reporting Services 讓您可以將任何報告匯出為 PPT、PPS、PPTX、PPSX、XPS 或 RPL 格式。
### **支援 Power BI 報表服務**
#### **Q: Aspose.Slides for Reporting Services 是否支援 Power BI？**
**A**: 是的。Aspose.Slides for Reporting Services 支援在 Power BI 中匯出分頁報表 (RDL)。
### **安裝**
#### **Q: 安裝程式無法啟動。手動安裝也無法得到預期結果。**
**A** : 請確定系統已安裝 .NET Framework 3.5。
#### **Q: 安裝 Aspose.Slides for Reporting Services 後缺少匯出選項。**
**A**: 如果 rssrvpolicy.config 中的任一 CodeGroup 未正確運作，設定檔解析器可能會跳過該群組的最後區段。因此，請將所有與 Aspose.Slides for Reporting Services 相關的 CodeGroup 移至包含 Aspose.Slides for Reporting Services CodeGroups 區塊的最上方。
#### **Q: 無法載入檔案或組件 Aspose.Slides.ReportingServices (Execution permission cannot be acquired \ Exception from HRESULT: 0x80131418)。**
**A**: 錯誤代碼 (0x80131418) 表示 dll 模組的權限不足。這可能是因為安全功能阻止了對從其他電腦取得的 .dll 檔案的完整存取。請開啟該 dll 檔案的內容設定視窗，於「安全性」面板中點選「解除封鎖」按鈕即可解決。
#### **Q: 找不到授權檔案 'Aspose.Slides.Reporting.Services.lic'。**
**A**: 授權檔必須與 dll 同層，或放置於 Program Files(x86)\Aspose\Slides\ 目錄下。
### **匯出設定**
#### **Q: 如何變更匯出報告中超連結的顏色？**
**A**: 每個 Aspose.Slides for Reporting Services 的 rsreportserver.config 呈現延伸套件都有各自的設定。要變更超連結顏色，只需在 <HyperlinkColor> 區段中設定所需值。
#### **Q: 在匯出的簡報中，表格內的文字被垂直拉伸。**
**A**: 這是為了讓文件更易閱讀。若要讓表格中的文字顯示與報告中相同，請在 rsreportserver.config 設定檔中將相應的 Aspose.Slides for Reporting Services 延伸套件設定為「Normal」。