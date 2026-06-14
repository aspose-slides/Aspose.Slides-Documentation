---
title: Xuất báo cáo sang định dạng RPL
type: docs
weight: 110
url: /vi/reportingservices/exporting-reports-to-rpl-format/
---

{{% alert color="primary" %}} 
Aspose.Slides sử dụng các báo cáo ở định dạng RPL (Report Processing Language) để hiển thị. Trang này trình bày cách xuất báo cáo sang định dạng RPL.
{{% /alert %}} 

Trong nhiều trường hợp, khách hàng phải chia sẻ các báo cáo có vấn đề để Aspose xử lý. Khi các báo cáo được chia sẻ ở dạng RDL, bộ dữ liệu hoặc schema cũng được cung cấp để chúng tôi có thể tái tạo vấn đề. Đôi khi, việc chỉ chia sẻ báo cáo RDL cùng bộ dữ liệu vẫn chưa đủ để giải quyết hoàn toàn. Trong những trường hợp này, chúng tôi khuyến nghị bạn xuất báo cáo sang định dạng RPL và chia sẻ tệp RPL cho chúng tôi. Tệp RPL cũng bao gồm bộ dữ liệu đã sử dụng. Nhờ vậy, việc xuất sang RPL trở nên dễ dàng hơn và có thể chia sẻ ngay lập tức với chúng tôi.

Thực hiện các bước sau:

1. Sao chép Aspose.ReportingServices.Debug.Rpl.dll vào thư mục bin của Reporting Services (thường nằm ở c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\bin).

{{% alert color="primary" %}} 
Aspose.ReportingServices.Debug.Rpl.dll có sẵn trong các phiên bản mới nhất của Aspose.Slides cho Reporting Services, có thể tải xuống từ [Trang phát hành](https://releases.aspose.com/slides/vi/reportingservices/).
{{% /alert %}} 

2. Thêm phần mở rộng này vào thẻ **<Render>** của tệp **rsreportserver.config** (thường nằm ở c:\Program Files\Microsoft SQL Server\MSRS10_50.SQL2008R2\Reporting Services\ReportServer\rsreportserver.config)

``` xml



//Thêm thẻ này vào phần tử <Render> element 



   <Extension Name="ASRPLDEBUG" Type="Aspose.Slides.ReportingServices.DebugRplRenderer,Aspose.ReportingServices.Debug.Rpl" >

	  </Extension>


```

3. Chỉ định đường dẫn tới các tệp RPL kết quả bằng cách chỉnh sửa phần tử path.

4. Cấp quyền cho Aspose.ReportingServices.Debug.Rpl.dll để thực thi theo cách sau: mở C:\Program Files\Microsoft SQL Server\<Instance>\Reporting Services\ReportServer\rssrvpolicy.config và thêm đoạn này vào mục cuối cùng trong phần tử **<CodeGroup>** thứ hai từ ngoài (phải là **<CodeGroup class="FirstMatchCodeGroup" version="1" PermissionSetName="Execution" Description="This code group grants MyComputer code Execution permission. ">**) :

``` xml



<CodeGroup>

  ...

  <CodeGroup>

    ...

    <!--Bắt đầu ở đây.-->

				<CodeGroup class="UnionCodeGroup"

					version="1"

					PermissionSetName="FullTrust"

					Name="Aspose.Rpl_Debug_for_Reporting_Services"

					Description="Code group for my Aspose.Rpl.Debug rendering extension">

			<IMembershipCondition class="StrongNameMembershipCondition" version="1" PublicKeyBlob="00240000048000009400000006020000002400005253413100040000010001006b80fcda1455ae4cf3919835348890372b899f004785c4254480f2278db2867313aedbf0224038beff12cb44da0493dcfadaef543dce262358ae3f6e383bfd9466d1b59828a5c1ff4097ec0ef4a087bd7090c2a0de710ffa2d2f045e0626f40a32d63c9bde1fc9538d478a1caac9155563a103b275e646a728e711057308dbe3" />

				</CodeGroup>

    <!--Kết thúc ở đây.-->

  </CodeGroup>

</CodeGroup>


```

5. Khởi động lại Reporting Services. Bạn sẽ thấy tùy chọn Aspose.Rpl trong menu Xuất.

Tùy chọn "Rpl export" sẽ xuất hiện trên bảng điều khiển xuất. Bạn cần xuất báo cáo sang RPL và chia sẻ tệp RPL.